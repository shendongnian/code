    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ChildrenProcessKiller
    {
      static class ChildrenProcessKiller
      {
        [STAThread]
        static void Main(string[] args)
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
    
          string message = "This is a watcher that enables to kill all descendants process of a given parent process\n";
          message += "when the parent process exits (even if the parent process crashes) \n\n";
          message += "Usage : " + Application.ExecutablePath + " parentProcessId";
    
          if (args.Length != 1)
          {
            MessageBox.Show(message);
            System.Environment.Exit(1);
          }
          
          int parentProcessId;
          if (!Int32.TryParse(args[0], out parentProcessId))
          {
            MessageBox.Show(message);
            System.Environment.Exit(1);
          }
          
          try
          {
            mParentProcess = Process.GetProcessById(parentProcessId);
          }
          catch (System.ArgumentException ex)
          {
            //Parent process cannot be found!
            System.Environment.Exit(2);
          }
          Run();
        }
    
        private static List<Process> mChildrenProcesses;
        private static Process mParentProcess;
    
        private static void Run()
        {
          int thisProcessId = Process.GetCurrentProcess().Id;
          while ( ! mParentProcess.HasExited )
          {
            RefreshChildrenProcesses();
            System.Threading.Thread.Sleep(1000);
          }
    
          foreach (Process childProcess in mChildrenProcesses)
          {
            if ((!childProcess.HasExited) && (childProcess.Id != thisProcessId))
            {
              KillGracefullyThenViolently(childProcess);
            }
          }
        }
    
        private static void KillGracefullyThenViolently(Process process)
        {
          if (process.HasExited)
            return;
    
          try
          {
            process.CloseMainWindow();
          }
          catch (PlatformNotSupportedException)
          {}
          catch (InvalidOperationException)
          {}//do nothing : this app is meant to be "unstoppable", unless the parent process has exited
    
          for (int i = 0; i < 15; i++)
          {
            System.Threading.Thread.Sleep(100);
            if (process.HasExited)
              return;
          }
          
          try
          {
            process.Kill();
          }
          catch (System.ComponentModel.Win32Exception)
          {}
          catch(NotSupportedException)
          {}
          catch(InvalidOperationException)
          {} //same comment here
        }
    
        private static void RefreshChildrenProcesses()
        {
          if (mParentProcess.HasExited)
            return;
          List<Process> newChildren;
          try
          {
            newChildren = Utils.ProcessTree.GetProcessDescendants(mParentProcess);
            mChildrenProcesses = newChildren;
          }
          catch (System.Exception ex)
          {
            ; 
          }
        }
    
    
      }
    }
  
  
