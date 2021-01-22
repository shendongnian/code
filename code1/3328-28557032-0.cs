    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace RegExTrial
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sql = String.Empty;
                string path=@"D:\temp\sample.sql";
                using (StreamReader reader = new StreamReader(path)) {
                    sql = reader.ReadToEnd();
                }            
                //Select any GO (ignore case) that starts with at least 
                //one white space such as tab, space,new line, verticle tab etc
                string pattern="[\\s](?i)GO(?-i)";
                
                Regex matcher = new Regex(pattern, RegexOptions.Compiled);
                int start = 0;
                int end = 0;
                Match batch=matcher.Match(sql);
                while (batch.Success) {
                    end = batch.Index;
                    string batchQuery = sql.Substring(start, end - start).Trim();
                    //execute the batch
                    ExecuteBatch(batchQuery);
                    start = end + batch.Length;
                    batch = matcher.Match(sql,start);
                }
    
            }
    
            private static void ExecuteBatch(string command)
            { 
                //execute your query here
            }
    
        }
    }
