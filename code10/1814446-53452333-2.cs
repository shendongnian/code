        class Orchestration
        {
            private SortedList<RankedRunner, RankedRunner> runners;
            Orchestration()
            {
                // We need to sort our runners based on their rank. If two runners
                // have the same rank then use the object comparator.
                // Note that x and y get swapped so the largest rank will be ordered first.
                this.runners = new SortedList<RankedRunner, RankedRunner>(
                    Comparer<RankedRunner>.Create(
                        (x, y) =>
                        {
                            return x.Rank == y.Rank
                                ? Comparer<RankedRunner>.Default.Compare(y, x)
                                : Comparer<int>.Default.Compare(y.Rank, x.Rank);
                        }));
            }
            Orchestration addRankedRunner(RankedRunner runner)
            {
                this.runners.Add(runner, runner);
                return this;
            }
            void Input(int input)
            {  
                // Find the highest ranked runner that is runnable.
                foreach(RankedRunner runner in runners.Values)
                {
                    if(runner.Runnable(input))
                    {
                        runner.Run();
                        break;
                    }
                }
            }
        }
