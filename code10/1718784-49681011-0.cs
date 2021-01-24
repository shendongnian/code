        private List<Task> Merge(List<Task> list)
        {
            var result = new List<Task>();
            var maxId = list.Max(x => x.Id) + 1;
            // order list for this algo to work
            var listO = list.OrderByDescending(x => x.Action).ThenBy(x => x.Source).ToArray();
            
            // create seed and counter
            Task seed = listO[0];
            var ctr = 0;
            for (var i = 0; i < listO.Length - 1; i++)
            {
                if (listO[i + 1].Source == listO[i].Target && listO[i + 1].Action == listO[i].Action && listO[i + 1].Action == seed.Action)
                {
                    // if the next is the last, merge it now
                    if (i + 1 == listO.Length - 1)
                        result.Add(new Task() { Id = maxId++, Action = seed.Action, Source = seed.Source, Target = listO[i].Target });
                    // the next item qualifies for merge, move to next
                    ctr++;
                    continue;
                }
                // next item does not qualify for merge, merge what we have or just add the item if ctr == 0
                result.Add(ctr == 0 ? seed : new Task() { Id = maxId++, Action = seed.Action, Source = seed.Source, Target = listO[i].Target });
                
                // reset seed record + counter
                seed = listO[i+1];
                ctr = 0;
                // if the next item is the last, it belongs in the list as is
                if (i + 1 == listO.Length - 1) result.Add(seed);                
            }
            return result;
        }
