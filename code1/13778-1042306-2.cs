    class SetVersion
    {
        static void Main(string[] args)
        {
            String FilePath = args[0];
            String MajVersion=args[1];
            String MinVersion = args[2];
            String BuildNumber = args[3];
            string RevisionNumber = null;
            StreamReader Reader = File.OpenText(FilePath);
            string contents = Reader.ReadToEnd();
            Reader.Close();
           
            MatchCollection match = Regex.Matches(contents, @"\[assembly: AssemblyVersion\("".*""\)\]", RegexOptions.IgnoreCase);
         // MatchCollection match = Regex.Matches(contents, "(^[//]?)\\[assembly: AssemblyVersion\\(\"\\d*\\.\\d*\\.\\d*\"\\)\\]", RegexOptions.IgnoreCase);
            if (match[0].Value != null)
            {
                string strRevisionNumber = match[0].Value;
