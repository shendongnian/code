    string[] regexStrings = ... // some regex match code here.
    
    // get all of the directories below some root that match my initial criteria.
    var directories = from d in root.GetDirectories("*", SearchOption.AllDirectories)
                      where (d.Attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0
                            && (d.GetDirectories().Where(dd => (dd.Attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0).Count() > 0// has directories
                                || d.GetFiles().Where(ff => (ff.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0).Count() > 0) // has files)
                      select d;
    
    // filter the list of all directories based on the strings in the regex array
    var filteredDirs = directories.Where(d =>
        {
            foreach (string pattern in regexStrings)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(d.FullName, pattern))
                {
                    return true;
                }
            }
            return false;
        });
