    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?<=FROM\s+\[?)(Dbname)(?=\..+?\]?)";
            string substitution = @"newDbName";
            string input = @"select * from DBName.TableName
    select * from [DbName.TableName]";
            RegexOptions options = RegexOptions.Multiline | RegexOptions.IgnoreCase;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
