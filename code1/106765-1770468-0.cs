    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace Launcher
    {
      public static class Program
      {
        public static void Main(string[] args)
        {
    
            Process firefox = new Process();
    
            firefox.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            firefox.StartInfo.Arguments = "-P MyProfile -no-remote";
    
            firefox.Start();
    
        }
      }
    }
