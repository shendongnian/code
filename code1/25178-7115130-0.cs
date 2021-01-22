    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace PidExamples
    {
        class ParentPid
        {
            static void Main(string[] args)
            {
                var childPidToParentPid = GetAllProcessParentPids();
                int currentProcessId = Process.GetCurrentProcess().Id;
    
                Console.WriteLine("Current Process ID: " + currentProcessId);
                Console.WriteLine("Parent Process ID: " + childPidToParentPid[currentProcessId]);
            }
            
            public static Dictionary<int, int> GetAllProcessParentPids()
            {
                var childPidToParentPid = new Dictionary<int, int>();
    
                var processCounters = new SortedDictionary<string, PerformanceCounter[]>();
                var category = new PerformanceCounterCategory("Process");
    
                // As the base system always has more than one process running, 
                // don't special case a single instance return.
                var instanceNames = category.GetInstanceNames();
                foreach(string t in instanceNames)
                {
                    try
                    {
                        processCounters[t] = category.GetCounters(t);
                    }
                    catch (InvalidOperationException)
                    {
                        // Transient processes may no longer exist between 
                        // GetInstanceNames and when the counters are queried.
                    }
                }
    
                foreach (var kvp in processCounters)
                {
                    int childPid = -1;
                    int parentPid = -1;
    
                    foreach (var counter in kvp.Value)
                    {
                        if ("ID Process".CompareTo(counter.CounterName) == 0)
                        {
                            childPid = (int)(counter.NextValue());
                        }
                        else if ("Creating Process ID".CompareTo(counter.CounterName) == 0)
                        {
                            parentPid = (int)(counter.NextValue());
                        }
                    }
    
                    if (childPid != -1 && parentPid != -1)
                    {
                        childPidToParentPid[childPid] = parentPid;
                    }
                }
    
                return childPidToParentPid;
            }
        }
    }    
    
