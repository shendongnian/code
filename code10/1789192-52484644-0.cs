    public void Main()
        {
            string p = "C:\\Users\\nthaku01\\Desktop\\NewEXPOLD.txt";
            FileInfo fi = new FileInfo(p);
            String fileName = fi.FullName;
            Dts.Variables["User::vLastFilename"].Value = fileName.ToString();
            MessageBox.Show(Dts.Variables["User::vLastFilename"].Value.ToString());
            Dts.TaskResult = (int)eScriptResults.enumSuccess;
        }
        enum eScriptResults
        {
            enumSuccess = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            enumFailure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
