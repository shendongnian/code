    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace UpdateVersion
    {
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
                if (match[0].Value != null)
                {
                    string strRevisionNumber = match[0].Value;
    			
                    RevisionNumber = strRevisionNumber.Substring(strRevisionNumber.LastIndexOf(".") + 1, (strRevisionNumber.LastIndexOf("\"")-1) - strRevisionNumber.LastIndexOf("."));
                    
    				String replaceWithText = String.Format("[assembly: AssemblyVersion(\"{0}.{1}.{2}.{3}\")]", MajVersion, MinVersion, BuildNumber, RevisionNumber);
                    string newText = Regex.Replace(contents, @"\[assembly: AssemblyVersion\("".*""\)\]", replaceWithText);
                    
    				StreamWriter writer = new StreamWriter(FilePath, false);
                    writer.Write(newText);
                    writer.Close();
                }
                else
                {
                    Console.WriteLine("No matching values found");
                }
    		}
        }
    }
