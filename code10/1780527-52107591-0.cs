        foreach (WorkItem wi in wis)
        {
            if (wi.Relations != null)
            {
                foreach (WorkItemRelation wir in wi.Relations)
                {
                    Console.WriteLine(wir.Rel);
                    Console.WriteLine(wir.Url);
                }
            }
        }
