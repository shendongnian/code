        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Diagnostics;
        
        namespace TestAsConsoleApp
        {
            class Program
            {
                static Process Shell;
                static void Main(string[] args)
                {
                    Shell = new Process();
                    Shell.StartInfo.FileName = "cmd";
        
                    Shell.StartInfo.UseShellExecute = false;
                    Shell.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Shell.StartInfo.CreateNoWindow = true;
        
                    Shell.StartInfo.RedirectStandardInput = true;
                    Shell.StartInfo.RedirectStandardOutput = true;
                    Shell.StartInfo.RedirectStandardError = true;
        
                    Shell.Start();
                    //Shell.StandardInput.WriteLine("dir");
        
                    Shell.EnableRaisingEvents = true;
                    Shell.OutputDataReceived += new DataReceivedEventHandler(Shell_OutputDataReceived);
                    Shell.BeginOutputReadLine();
    //read input from your programs input and forward that to the created cmd 's input
                    do
                    {
                        string aLine = Console.ReadLine();
                        Shell.StandardInput.WriteLine(aLine);
                        if (aLine.ToLower() == "exit")
                            break;
                    }while(true);
        
                    Shell.WaitForExit();
                }
        
                static void Shell_OutputDataReceived(object sender, DataReceivedEventArgs e)
                {
                    if (e.Data != null)
                        Console.WriteLine(e.Data);
                }
            }
        }
