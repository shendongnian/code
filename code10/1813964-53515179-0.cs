    public void Main()
        {
            string FromDate = Dts.Variables["User::FromDate"].Value.ToString();
            string ToDate = Dts.Variables["User::ToDate"].Value.ToString();
            string TEST_Path = Dts.Variables["$Package::TEST_Path"].Value.ToString();
            string TEST_ExePath = Dts.Variables["$Package::TEST_ExePath"].Value.ToString();
            var strCmdText = @"c:\program files\dotnet\dotnet.exe";
            
            var parameters = TEST_ExePath.ToString() + " --fromDateTime " + FromDate.ToString() + " --toDateTime " + ToDate.ToString();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(strCmdText, parameters);
            p.StartInfo.WorkingDirectory = TEST_Path;
           
            p.StartInfo.UseShellExecute = false;
            bool fireAgain = false;
            try
            {
                p.Start();
            }
            catch(Exception e)
            {
                Dts.Events.FireError(0, "Script Task Example", "Exception encountered: " + e.ToString(), String.Empty, 0);
            }
            
            p.WaitForExit();
            Dts.Events.FireInformation(0, "Script Task Example", "Exit code = " + p.ExitCode.ToString(), String.Empty, 0, ref fireAgain);
            Dts.TaskResult = (int)ScriptResults.Success;
        }
