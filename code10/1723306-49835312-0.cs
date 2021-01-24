    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Linq;
    namespace dead_link_finder
    {
        static class Program
        {
            private static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var fileToScan = Console.ReadLine();
                var links = File.ReadAllLines(fileToScan);
                var deadLinks = new List<string>();
                var webClient = new WebClient();
                foreach (var link in links)
                {
                    try
                    {
                        var content = webClient.DownloadString(link);
                        if (content.Contains("text-danger"))
                        {
                            deadLinks.Add(link);
                        }
                    }
                    catch (WebException wex)
                    {
                        if (wex.Status == WebExceptionStatus.NameResolutionFailure )
                        {
                            deadLinks.Add(link);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Found: " + deadLinks.Count + " dead links in the collection.");
                Console.WriteLine();
                Thread.Sleep(5000);
                Console.WriteLine("Removing the dead links, please wait...");
                var justTheGoodLinks = links.Except(deadLinks);
                File.WriteAllLines(fileToScan, justTheGoodLinks);
                Console.WriteLine();
                Console.WriteLine("Finished...");
                Console.ReadKey(true);
            }
        }
    }
