    using System;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static string createFormatString(string template, params string[] parameters)
        {
            template = template.Replace("{", "{{");
    
            for (int i =0; i < parameters.Length; ++i) {
                template = template.Replace(
                    parameters[i].Replace("{", "{{"),
                    "{" + i + "}");
            }
    
            return template;
        }
    
        static void Main(string[] args)
        {
            string template = @"<a href=""http://www.domain.com"" target=""_blank"">title</a>";
            string[] domains = File.ReadAllLines("domain.txt");
            string[] titles = File.ReadAllLines("title.txt");
    
            int n = domains.Length;
            if (titles.Length != n)
                throw new InvalidDataException("There must be the same number domains and titles.");
    
            string[] results = new string[n];
            string formatString = createFormatString(template, "www.domain.com", "title");
    
            for (int i = 0; i < n; ++i)
            {
                results[i] = string.Format(formatString, domains[i], titles[i]);
            }
    
            File.WriteAllLines("file1.txt", results.Take(n / 2).ToArray());
            File.WriteAllLines("file2.txt", results.Skip(n / 2).ToArray());
        }
    }
