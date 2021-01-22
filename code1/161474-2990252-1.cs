        private SearchResult FindInDict()
        {
            SearchResult result = new SearchResult();
            result.SeachType = "FindInDict";
            result.itterations = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            if (dictStrBoundryTask.ContainsKey(NameOfFirst))
            {
                TaskBase t = dictStrBoundryTask[NameOfFirst];
            }
            timer.Stop();
            result.firstItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            if (dictStrBoundryTask.ContainsKey(NameOfLast))
            {
                TaskBase t = dictStrBoundryTask[NameOfLast];
            }
            timer.Stop();
            result.lastItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            if (dictStrBoundryTask.ContainsKey(NameOfNotFound))
            {
                TaskBase t = dictStrBoundryTask[NameOfNotFound];
            }
            timer.Stop();
            result.notFoundItem = timer.Elapsed.TotalMilliseconds;
            return result;
        }
        private SearchResult FindInHashDict()
        {
            SearchResult result = new SearchResult();
            result.SeachType = "FindInHashDict";
            result.itterations = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            if (dictIntBoundryTask.ContainsKey(NameOfFirst.GetHashCode()))
            {
                TaskBase t = dictIntBoundryTask[NameOfFirst.GetHashCode()];
            }
            timer.Stop();
            result.firstItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            if (dictIntBoundryTask.ContainsKey(NameOfLast.GetHashCode()))
            {
                TaskBase t = dictIntBoundryTask[NameOfLast.GetHashCode()];
            }
            timer.Stop();
            result.lastItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            if (dictIntBoundryTask.ContainsKey(NameOfNotFound.GetHashCode()))
            {
                TaskBase t = dictIntBoundryTask[NameOfNotFound.GetHashCode()];
            }
            timer.Stop();
            result.notFoundItem = timer.Elapsed.TotalMilliseconds;
            return result;
        }
        private SearchResult FindInArray()
        {
            SearchResult result = new SearchResult();
            result.SeachType = "FindInArray";
            result.itterations = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            foreach (TaskBase t in arrayBoundaryTask)
            {
                if (t.Name == NameOfFirst)
                {
                    break;
                }
            }
            timer.Stop();
            result.firstItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            foreach (TaskBase t in arrayBoundaryTask)
            {
                if (t.Name == NameOfLast)
                {
                    break;
                }
            }
            timer.Stop();
            result.lastItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            foreach (TaskBase t in arrayBoundaryTask)
            {
                if (t.Name == NameOfNotFound)
                {
                    break;
                }
            }
            timer.Stop();
            result.notFoundItem = timer.Elapsed.TotalMilliseconds;
            return result;
        }
        private SearchResult FindInList()
        {
            SearchResult result = new SearchResult();
            result.SeachType = "FindInList";
            result.itterations = 1;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            TaskBase t = listBoundaryTask.Find(x => x.Name == NameOfFirst);
            if (t!=null)
            {
                
            }
            timer.Stop();
            result.firstItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            t = listBoundaryTask.Find(x => x.Name == NameOfLast);
            if (t != null)
            {
            }
            timer.Stop();
            result.lastItem = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            t = listBoundaryTask.Find(x => x.Name == NameOfNotFound);
            if (t != null)
            {
            }
            timer.Stop();
            result.notFoundItem = timer.Elapsed.TotalMilliseconds;
            return result;
        }
