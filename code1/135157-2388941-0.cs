            Process         proc                = new Process();
            StringBuilder   sb                  = new StringBuilder();
            string[]        aTarget             = target.Split(PATH_SEPERATOR); 
            string          errorMessage;
            string          outputMessage;
            foreach (string parm in parameters)
            {
                sb.Append(parm + " ");
            }
            proc.StartInfo.FileName                 = target;
            proc.StartInfo.RedirectStandardError    = true;
            proc.StartInfo.RedirectStandardOutput   = true;
            proc.StartInfo.UseShellExecute          = false;
            proc.StartInfo.Arguments                = sb.ToString();
            proc.Start();
            proc.WaitForExit
                (
                    (timeout <= 0)
                    ? int.MaxValue : timeout * NO_MILLISECONDS_IN_A_SECOND * NO_SECONDS_IN_A_MINUTE
                );
            errorMessage    = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            outputMessage   = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
