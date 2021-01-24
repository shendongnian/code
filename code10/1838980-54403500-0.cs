    var prz = Process.Start("C:\\Program Files (x86)\\Adobe\\Acrobat Reader DC\\Reader\\AcroRd32.exe", "/h /t \"" + YOURPDFFILE + "\" \"" + YOURPRINTER + "\"");
               
                bool loop = true;
                while (loop)
                {
    //u can use Thread.Sleep(x) too;
                    prz.WaitForExit(500);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(
           "SELECT * " +
           "FROM Win32_Process " +
           "WHERE ParentProcessId=" + prz.Id);
                    ManagementObjectCollection collection = searcher.Get();
                    if (collection.Count > 0)
                    {
                        foreach (var item in collection)
                        {
                            UInt32 childProcessId = (UInt32)item["ProcessId"];
                            if ((int)childProcessId != Process.GetCurrentProcess().Id)
                            {
                                
                                Process childProcess = Process.GetProcessById((int)childProcessId);
                 
    //If a File is open the Title begins with "Filename - Adobe ...", but after print/closing the recent window starts with "Adobe Acr..."
               if(childProcess.MainWindowTitle.StartsWith("Adobe Acrobat"))
                                    {
                                    loop = false;
                                    break;
                                }
                            }
                        }
                    }
                }
               //"Recent" Window found, lets kill the Process
                prz.Kill();
    // Now here u can move or Delete the pdf file
 
