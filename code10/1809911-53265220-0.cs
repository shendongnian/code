    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using LibGit2Sharp;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pathToFile = "a.txt";
                var commitSha = "807736c691865a8f03c6f433d90db16d2ac7a005";
                var repoPath = @"path/to/repo";
    
                using (var repo =
                    new Repository(repoPath))
                {
                    var commit = repo.Commits.Single(c => c.Sha == commitSha);
                    var file =  commit[pathToFile];
    
                    var blob = file.Target as Blob;
                    using (var content = new StreamReader(blob.GetContentStream(), Encoding.UTF8))
                    {
                        var fileContent = content.ReadToEnd();
                        Console.WriteLine(fileContent);
                    }
                }
            }
        }
    }
