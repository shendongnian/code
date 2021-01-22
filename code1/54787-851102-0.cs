    public static bool ExecuteSvnCommandWithFileInput( string command, string arguments, string filePath, out string result, out string errors )
    {
        bool retval = false;
        string output = string.Empty;
        string errorLines = string.Empty;
        Process svnCommand = null;
        var psi = new ProcessStartInfo( command );
    
        psi.RedirectStandardInput = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        psi.WindowStyle = ProcessWindowStyle.Hidden;
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
    
        try
        {
            Process.Start( psi );
            psi.Arguments = arguments;
            svnCommand = Process.Start( psi );
    
            var file = new FileInfo(filePath);
            StreamReader reader = file.OpenText();
            string fileContents = reader.ReadToEnd();
            reader.Close();
    
            StreamWriter myWriter = svnCommand.StandardInput;
    	    StreamReader myOutput = svnCommand.StandardOutput;
            StreamReader myErrors = svnCommand.StandardError;
    
            myWriter.AutoFlush = true;
            myWriter.Write(fileContents);
            myWriter.Close();
    
            output = myOutput.ReadToEnd();
            errorLines = myErrors.ReadToEnd();
    
            // Check for errors
            if ( errorLines.Trim().Length == 0 )
            {
                retval = true;
            }
        }
        catch ( Exception ex )
        {
            string msg = ex.Message;
            errorLines += Environment.NewLine + msg;
        }
        finally
        {
            if (svnCommand != null)
            {
                svnCommand.Close();
            }
        }
    
        result = output;
        errors = errorLines;
    
        return retval;
    }
