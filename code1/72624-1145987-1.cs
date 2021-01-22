        private static void LaunchProcess()
        {
            Process build = new Process();
            build.StartInfo.WorkingDirectory =  @"dir";
            build.StartInfo.Arguments = "";
            build.StartInfo.FileName = "my.exe";
            build.StartInfo.UseShellExecute = false;
            build.StartInfo.RedirectStandardOutput = true;
            build.StartInfo.RedirectStandardError = true;
            build.StartInfo.CreateNoWindow = true;
            build.ErrorDataReceived += build_ErrorDataReceived;
            build.OutputDataReceived += build_ErrorDataReceived;
            build.EnableRaisingEvents = true;
            build.Start();
            build.BeginOutputReadLine();
            build.BeginErrorReadLine();
            build.WaitForExit();
        }
        // write out info to the display window
        static void build_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string strMessage = e.Data;
            if (richTextBox != null && !String.Empty(strMessage))
            {
                App.Instance.Dispatcher.BeginInvoke(DispatcherPriority.Send, (ThreadStart)delegate()
                {
                    Paragraph para = new Paragraph(new Run(strMessage));
                    para.Margin = new Thickness(0);
                    para.Background = brushErrorBrush;
                    box.Document.Blocks.Add(para);
                });
           }
        } 
