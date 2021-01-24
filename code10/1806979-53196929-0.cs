    using System;
    using System.Collections.Generic;
    using HtmlAgilityPack;
    class Program
    {
        private static string domainUrl = @"https://www.dice.com";
        private static HtmlWeb web = new HtmlWeb();
        private static List<JobInfo> jobsInfoList = new List<JobInfo>();
        static void Main(string[] args)
        {
            Console.WriteLine("Wait a bit until all pages are downloaded..\n");
            JustDoIt();
            AndPrintResults();
            Console.ReadKey();
        }
        static void JustDoIt()
        {
            var url = domainUrl + @"/jobs?q=information+technology&l=arkansas#dice";
            var htmlDoc = web.Load(url);
            var jobsNodes = htmlDoc.DocumentNode.SelectNodes("//*[@class='complete-serp-result-div']");
            foreach (var jobNode in jobsNodes)
            {
                var jobInfo = new JobInfo
                {
                    Title = jobNode.SelectSingleNode(".//span[@itemprop='title']").InnerText,
                    CompanyName = jobNode.SelectSingleNode(".//span[@itemprop='name']").InnerText,
                    Location = jobNode.SelectSingleNode(".//span[@itemprop='addressLocality']").InnerText,
                    Summary = jobNode.SelectSingleNode(".//span[@itemprop='description']").InnerText,
                };
                var hrefToDescriptionPage = jobNode.SelectSingleNode(".//a[contains(@id,'position')]").Attributes["href"].Value;
                var descriptionPage = web.Load(domainUrl + hrefToDescriptionPage);
                jobInfo.Description = descriptionPage.DocumentNode.SelectSingleNode("//*[@id='jobdescSec']").InnerHtml;
                jobsInfoList.Add(jobInfo);
            }
        }
        static void AndPrintResults()
        {
            foreach (var job in jobsInfoList)
            {
                Console.WriteLine($"Title: {job.Title}");
                Console.WriteLine($"CompanyName: {job.CompanyName}");
                Console.WriteLine($"Location: {job.Location}");
                Console.WriteLine($"Summary: {job.Summary}");
                // NOTE!!! I am trimming description up to 1000 symbols here just to keep console clean
                var trimmedDescription = job.Description.Length > 1000 ? job.Description.Substring(0, 1000) : job.Description;
                Console.WriteLine($"Description:\n {trimmedDescription}");
                Console.WriteLine($"==================================================================\n");
            }
        }
        public class JobInfo
        {
            public string CompanyName { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
        }
    }
