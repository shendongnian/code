                    System.Windows.Forms.PrintDialog printDialog = new PrintDialog();
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(Application.StartupPath + "/PrintingDocketFile/PrintCustomerOrder.txt");
                    psi.Verb = "PRINT";
                    //Process.Start(psi);
                    //psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    //---------------------------------------------------
                    
                    psi.CreateNoWindow = false;
                    psi.UseShellExecute = true;
                    psi.FileName = Application.StartupPath + "/PrintingDocketFile/PrintCustomerOrder.txt";
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    psi.Arguments =  @"%windir%\system32\notepad.exe"; 
                    //Process.Start(psi);
                    //------------------------------------------------------
                    /////////////////////----------------------------------
                    printProcess.StartInfo = psi;
                    /////psi.CreateNoWindow = true;
               
                    //psi.FileName = "Application.StartupPath" + "/PrintingDocketFile/PrintCustomerOrder.txt";
                    //p.StartInfo.FileName = "Notepad.EXE";
                    //p.StartInfo.Arguments = "/i /q \"" + installationPackages[i] + "\"";
                    printProcess.Start();
                    /////////////////////////-------------------------------
                    while (!printProcess.HasExited) ;
   
                    if (!printProcess.HasExited)
                    {
                        printProcess.Close();
                    }
