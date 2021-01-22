    using System;
    using System.Diagnostics;
    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;
    
    
    namespace BuildTasks
    {
        public class GetMercurialVersionNumber : Task
        {
            public override bool Execute()
            {
                bool bSuccess = true;
                try
                {
                    GetMercurialVersion();
                    Log.LogMessage(MessageImportance.High, "Build's Mercurial Id is {0}", MercurialId);
                }
                catch (Exception ex)
                {
                    Log.LogMessage(MessageImportance.High, "Could not retrieve or convert Mercurial Id. {0}\n{1}", ex.Message, ex.StackTrace);
                    Log.LogErrorFromException(ex);
                    bSuccess = false;
                }
                return bSuccess;
            }
    
            [Output]
            public string MercurialId { get; set; }
    
            [Required]
            public string DirectoryPath { get; set; }
    
            private void GetMercurialVersion()
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WorkingDirectory = DirectoryPath;
                p.StartInfo.FileName = "hg";
                p.StartInfo.Arguments = "id";
                p.Start();
    
                string output = p.StandardOutput.ReadToEnd().Trim();
                Log.LogMessage(MessageImportance.Normal, "Standard Output: " + output);
                
                string error = p.StandardError.ReadToEnd().Trim();
                Log.LogMessage(MessageImportance.Normal, "Standard Error: " + error);
                
                p.WaitForExit();
    
                Log.LogMessage(MessageImportance.Normal, "Retrieving Mercurial Version Number");
                Log.LogMessage(MessageImportance.Normal, output);
    
                Log.LogMessage(MessageImportance.Normal, "DirectoryPath is {0}", DirectoryPath);
                MercurialId = output;
    
            }
        }
