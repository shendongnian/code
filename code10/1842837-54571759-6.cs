    namespace ConsoleApp1
    {
        public struct Job
        {
            public string Site { get; set; }
            public string Account { get; set; }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                Dictionary<string, List<string>> Dict = new Dictionary<string, List<string>>();
    
                Dict.Add("Site-A", new List<string> { "Account-A", "Account-C" });
                Dict.Add("Site-B", new List<string> { "Account-A", "Account-E" });
                Dict.Add("Site-C", new List<string> { "Account-C", "Account-D" });
                Dict.Add("Site-D", new List<string> { "Account-A" });
                Dict.Add("Site-E", new List<string> { "Account-A" });
    
                // get esponsibilities count for each account
    
                Dictionary<string, int> responsibilitiesCount = GetResponsibilitiesCount(Dict);
    
                var jobs = new List<Job>();
    
                // building jobs list
    
                foreach (var kvp in Dict)
                {
                    var job = new Job();
                    job.Site = kvp.Key;
    
                    int minResponsibility = kvp.Value.Min(x => responsibilitiesCount[x]);
                    List<string> accounts = kvp.Value.Where(x => responsibilitiesCount[x] == minResponsibility).ToList();
                    int minJobs = accounts.Min(x => jobs.Count(y => y.Account == x));
                    job.Account = accounts.First(x => jobs.Count(y => y.Account == x) == minJobs);
                    jobs.Add(job);
                }
    
                // order jobs making sure distance between accounts has more than 1 job
    
                jobs = RandomOrderResponsibilities(jobs);
    
                foreach (var job in jobs)
                {
                    Console.WriteLine($"{job.Account} publish on {job.Site}");
                }
    
                Console.ReadLine();
            }
    
            private static Dictionary<string, int> GetResponsibilitiesCount(Dictionary<string, List<string>> dict)
            {
                Dictionary<string, int> responsibilitiesCount = new Dictionary<string, int>();
    
                foreach (var kvp in dict)
                {
                    foreach (var account in kvp.Value)
                    {
                        if (responsibilitiesCount.ContainsKey(account))
                        {
                            responsibilitiesCount[account]++;
                        }
                        else
                        {
                            responsibilitiesCount.Add(account, 1);
                        }
                    }
                }
    
                return responsibilitiesCount.ToDictionary(x => x.Key, x => x.Value);
            }
      
            private static List<Job> RandomOrderResponsibilities(List<Job> jobs)
            {
                bool couldComplete = true;
                int tryCount = 0;
    
                do
                {
                    // shuffle
                    jobs = jobs.OrderBy(a => Guid.NewGuid()).ToList();
    
                    for (int i = 1; i < jobs.Count; i++)
                    {
                        if (jobs[i].Account == jobs[i - 1].Account)
                        {
                            couldComplete = false;
    
                            for (int j = i + 1; j < jobs.Count; j++)
                            {
                                if (jobs[j].Account != jobs[i].Account)
                                {
                                    // swipe
                                    var temp = jobs[i];
                                    jobs[i] = jobs[j];
                                    jobs[j] = temp;
                                    couldComplete = true;
                                    break;
                                }
                            }
                        }
                    }
    
                    tryCount++;
                }
                while (!couldComplete && tryCount < 1000);
    
                return jobs;
            }
        }
    }
