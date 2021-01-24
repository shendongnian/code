    using System;
    using System.Collections.Generic;
    using System.IO;
    using Unity;
    using Unity.Injection;
    
    namespace StrategyPattern
    {
       public interface IFileBackupContext
       {
          FileStream ForBackup { set; }
          (bool success, string strategy) Backup();
       }
    
       public interface IFileBackupStrategy 
       {
          (bool success, string name) Backup(FileStream fileToBackup);
       }
       
       internal class LocalBackUp : IFileBackupStrategy
       {
          private bool _success = false;
    
          public (bool success, string name) Backup(FileStream fileToBackup)
          {
             // code to do backup omitted
             var random = new Random(DateTime.Now.Millisecond);
             _success = (random.Next() % 3) == 0;
             if(_success) fileToBackup.Close();
             // it will set the value of _success to false if it was unsuccessful
             return (_success, "LocalBackUp");
          }
       }
      
       internal class CloudBackUp : IFileBackupStrategy
       {
          private bool _success = false;
    
          public (bool success, string name) Backup(FileStream fileToBackup)
          {
             // code to do backup omitted 
             var random = new Random(DateTime.Now.Millisecond);
             _success = (random.Next() % 3) == 0;
             if (_success) fileToBackup.Close();
             // it will set the value of _success to false if it was unsuccessful
    
             fileToBackup.Close();
             return (_success, "CloudBackUp");
          }
       }
    
       public class FileBackupContext : IFileBackupContext
       {
          private readonly IEnumerable<IFileBackupStrategy> _backupStrategies;
    
          public FileBackupContext(IEnumerable<IFileBackupStrategy> backupStrategies)
             => _backupStrategies = backupStrategies;
    
          public FileStream ForBackup { set; private get; }
    
          public (bool success, string strategy) Backup()
          {
             foreach (var strategy in _backupStrategies)
             {
                var (success, name) = strategy.Backup(ForBackup);
                if (success) return (true, name);
             }
    
             return (false, "");
          }
       }
    
       public class MyBackupClient
       {
          private IFileBackupContext _context;
    
          public MyBackupClient(IFileBackupContext context) => _context = context;
    
          public void BackgUpMyFile()
          {
             _context.ForBackup = new FileStream("d:\\myfile", FileMode.OpenOrCreate);
    
             (bool success, string strategy) = _context.Backup();
    
             if (!success)
             {
                Console.WriteLine("Failed to backup  the file");
                return;
             }
    
             Console.WriteLine($"File backed up using [{strategy}] strategy");
          }
       }
       
       public class Bootstrap
       {
          private readonly IUnityContainer _container;
          public Bootstrap()
          {
             _container = new UnityContainer();
    
    
             _container.RegisterType<IFileBackupContext, FileBackupContext>();
             _container.RegisterType<IFileBackupStrategy, LocalBackUp>("local");
             _container.RegisterType<IFileBackupStrategy, CloudBackUp>("cloud");
             _container.RegisterType<MyBackupClient>();
    
             _container.RegisterType<Func<IEnumerable<IFileBackupStrategy>>>(new InjectionFactory(c =>
                new Func<IEnumerable<IFileBackupStrategy>>(() =>
                   new[]
                   {
                      c.Resolve<IFileBackupStrategy>("local"),
                      c.Resolve<IFileBackupStrategy>("cloud")
                   }
                )));
          }
    
          public MyBackupClient GetClient() => _container.Resolve<MyBackupClient>();
       }
       
       class Program
       {
          static void Main(string[] args)
          {
             Console.WriteLine("Press ESC to quit ...");
             Console.WriteLine("Press any other key to try again.");
             Console.WriteLine();
             var client = new Bootstrap().GetClient();
             do
             {
                client.BackgUpMyFile();
             } while (Console.ReadKey().Key != ConsoleKey.Escape);
          }
       }
    }
