    using (TextWriter tw = new StreamWriter(@"C:\Info.txt"))
     {
         foreach (Process p in processes)
         {
             if (!String.IsNullOrEmpty(p.ProcessName))
             {
                 tw.WriteLine(string.Format("Process Name: {0} , Process GUI Title:{1}",p.ProcessName, p.MainWindowTitle));
             }
         }
     }
