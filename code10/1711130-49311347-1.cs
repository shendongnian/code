    string s1 = string.Format(@"{{\rtf1\ansi\r\b Commit ID:\b0 {0}\line\r", entry.ID);
    string s2 = string.Format(@"\b Author: \b0 {0}\line\r", entry.Author);
    string s3 = string.Format(@"\b Date: \b0 {0}\line\r", entry.Date.ToString("d"));
    string s4 = Environment.NewLine + Environment.NewLine + entry.Message + "}}";
    contents = (s1 + s2 + s3 + s4);
