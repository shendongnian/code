    using System;
    // add a reference to the com component
    // "Windows Script Host Object Model" for IWshRuntimeLibrary
    using IWshRuntimeLibrary;
    
    namespace ConsoleApplicationCSharp
    {  
      public class Foo
      {
        public static void Main(string[] args)
        {
          string pathLnk = @"C:\Users\scott\Desktop\wifi.lnk";
        
          WshShell shell = new WshShell();
          IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(pathLnk);
          Console.WriteLine("target path: " + shortcut.TargetPath);
          Console.WriteLine("argument: " + shortcut.Arguments);
          Console.WriteLine("working dir: " + shortcut.WorkingDirectory);
          return;
          
        }
      }
    }
