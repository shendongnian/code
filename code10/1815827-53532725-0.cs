    /// <summary>
    /// presents the user with a folder dialog
    /// Returns a full qualified directory chosen by the user
    /// </summary>
    /// <param name="WorkingPath">if a fully qualified directory name is provided, then the folder structure in the folder dialog will open to the directory selected</param>
    /// <returns>Returns a full qualified directory chosen by the user or if no directory was chosen, an empty string</returns>
    public string SetWorkingPath(string WorkingPath)
    {
        string tempSetWorkingPath = null;
        try
        {
            FolderBrowserDialog folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            // check our proposed working path and if its valid
            if((!string.IsNullOrEmpty(WorkingPath) && (WorkingPath != null)))
            {
                if (!Directory.Exists(WorkingPath))
                      WorkingPath = string.Empty;
            }
            else // if we are empty or null set us to empty
            {
                WorkingPath = string.Empty;
            }
            folderDlg.ShowNewFolderButton = true;
            folderDlg.Description = "Please select your working folder. This is where your PDF files will be saved.";
            folderDlg.RootFolder = Environment.SpecialFolder.Desktop;//.MyComputer;
            folderDlg.SelectedPath = (Convert.ToString(WorkingPath).Trim().Length == 0) ? ((int)Environment.SpecialFolder.MyComputer).ToString() : WorkingPath;
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                // make sure we have a backslash on the end of our directory string
                tempSetWorkingPath = PathAddBackslash(folderDlg.SelectedPath);
            }
            else
            {
                // return an empty string
                tempSetWorkingPath = string.Empty;
            }
        }
        catch (Exception ex)
        {
            tempSetWorkingPath = string.Empty;
            
            throw (ex);
        }
        return tempSetWorkingPath;
    }
    public string PathAddBackslash(string path)
    {
        // They're always one character but EndsWith is shorter than
        // array style access to last path character. Change this
        // if performance are a (measured) issue.
        string separator1 = Path.DirectorySeparatorChar.ToString();
        string separator2 = Path.AltDirectorySeparatorChar.ToString();
        // Trailing white spaces are always ignored but folders may have
        // leading spaces. It's unusual but it may happen. If it's an issue
        // then just replace TrimEnd() with Trim(). Tnx Paul Groke to point this out.
        path = path.TrimEnd();
        // Argument is always a directory name then if there is one
        // of allowed separators then I have nothing to do.
        if (path.EndsWith(separator1) || path.EndsWith(separator2))
            return path;
        // If there is the "alt" separator then I add a trailing one.
        // Note that URI format (file://drive:\path\filename.ext) is
        // not supported in most .NET I/O functions then we don't support it
        // here too. If you have to then simply revert this check:
        // if (path.Contains(separator1))
        //     return path + separator1;
        //
        // return path + separator2;
        if (path.Contains(separator2))
            return path + separator2;
        // If there is not an "alt" separator I add a "normal" one.
        // It means path may be with normal one or it has not any separator
        // (for example if it's just a directory name). In this case I
        // default to normal as users expect.
        return path + separator1;
    }
