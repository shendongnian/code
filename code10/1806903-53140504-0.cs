    private void button3_Click(object sender, EventArgs e)
        {
            string dirdes1 = dirdes.Text;
            string strCmdText;
            string locationAddress;
            string cdCommand;
            string doCompress;
            locationAddress = dirdes1;
            cdCommand  = "/C " + "cd " + locationAddress;
            strCmdText = "compact /c /s /a /i /exe:lzx";
            doCompress = "/C " + strCmdText + " *";
            Process lzx = new Process();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            lzx.StartInfo.FileName = "cmd.exe";
            lzx.StartInfo.UseShellExecute = false;
            lzx.StartInfo.WorkingDirectory = @locationAddress;
            lzx.StartInfo.Arguments = doCompress;
            lzx.StartInfo.RedirectStandardOutput = true;
            lzx.Start();
            _output.Text = lzx.StandardOutput.ReadToEnd();
            showCommand.Text = doCompress;
        }
