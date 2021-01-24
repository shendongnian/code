    public SvnResult CommitFiles_BySVNCmd(string filePath)
        {
            var fullPath = SvnHelper.FileCombine(filePath);
            var svnResult = new SvnResult();
            try
            {
                // svn add command
                var status = GetStatus(fullPath);
                //
                if (status.LocalContentStatus == SvnStatus.NotVersioned)
                {
                    var argumentsAdd = $@"add {fullPath}";
                    ProcessStart(argumentsAdd);
                }
                // svn commit command
                var argumentsCommit = $@"commit -m Commited_Automatically {fullPath}";
                ProcessStart(argumentsCommit);
                svnResult.Message = "Success
                svnResult.Status = true;
                return svnResult;
            }
            catch (SvnException se)
            {
                svnResult.Message = se.Message;
                svnResult.Status = false;
                return svnResult;
            }
        }
    private void ProcessStart(string arguments)
    {
         var processInfo = new ProcessStartInfo("svn", arguments);
         processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
         Process.Start(processInfo);
    }
    
