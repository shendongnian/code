    using System.IO;
    using System.Text.RegularExpressions;
    using System.Text;
    
    class MailExtracter
    {
    
        public static void ExtractEmails(string inFilePath, string outFilePath)
        {
            string data = File.ReadAllText(inFilePath); //read File 
            //instantiate with this pattern 
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(data);
    
            StringBuilder sb = new StringBuilder();
            
            foreach (Match emailMatch in emailMatches)
            {
                sb.AppendLine(emailMatch.Value);
            }
            //store to file
            File.WriteAllText(outFilePath, sb.ToString());
        }
    }
