        private string LaunchJScript(string xmlFilename, string xslFilename)
        {
            //string xslLocation = System.Web.HttpContext.Current.Server.MapPath("~/transform");
            string htmlFilename = xmlFilename.Substring(0, xmlFilename.LastIndexOf(".") + 1) + "html";
            
            // Start the child process.
            Process process = new Process();
            // Redirect the output stream of the child process.
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.FileName = xslLocation + "\\" + "xsltest.js";
            process.StartInfo.Arguments = xmlFilename + " " + xslFilename + " " + htmlFilename;
            process.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            // string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (File.Exists(htmlFilename))
            {
                _Logger.InfoFormat("Converted file is {0}", htmlFilename);
                return htmlFilename;
            }
            else
            {
                _Logger.ErrorFormat("Converted file {0} does not exist", htmlFilename);
                return string.Empty;
            }
        }
