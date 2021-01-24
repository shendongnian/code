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
                Dictionary<string, List<string>> permissionsDict = new Dictionary<string, List<string>>();
                permissionsDict.Add("Site-A", new List<string> { "Account-A", "Account-C" });
                permissionsDict.Add("Site-B", new List<string> { "Account-A", "Account-E" });
                permissionsDict.Add("Site-C", new List<string> { "Account-C", "Account-D" });
                permissionsDict.Add("Site-D", new List<string> { "Account-A" });
                permissionsDict.Add("Site-E", new List<string> { "Account-A" });
    
                // get esponsibilities count for each account
    
                Dictionary<string, int> responsibilitiesRate = GetResponsibilitiesCount(permissionsDict);
    
                List<Job> jobs = new List<Job>();
    
                // building jobs list
    
                foreach (var permission in permissionsDict)
                {
                    var job = new Job();
                    job.Site = permission.Key;
    
                    // for the current site, see what account has fewer responsibilities
                    int minResponsibilities = permission.Value.Min(x => responsibilitiesRate[x]);
                    string account = permission.Value.First(x => responsibilitiesRate[x] == minResponsibilities);
                    responsibilitiesRate[account]++;
    
                    job.Account = account;
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
    
                return responsibilitiesCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
    
            private static List<Job> RandomOrderResponsibilities(List<Job> jobs)
            {
                bool couldComplete = true;
                var maxIterations = 1000;
                var iterationCount = 0;
    
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
    
                    iterationCount++;
                } while (!couldComplete && iterationCount < maxIterations);
    
                return jobs;
            }
        }
    }
