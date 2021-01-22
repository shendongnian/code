            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo stratInfo = new System.Diagnostics.ProcessStartInfo();
            stratInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            stratInfo.FileName = "cmd.exe";
            stratInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = stratInfo;
            process.Start();
