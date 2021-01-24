    private static void TestForPreCountingParallel(List<TraiderItem> traiderItems, List<BaseItem> baseItems)
            {
                var watch = new Stopwatch();
                watch.Start();
                ConcurrentBag<TraiderItem> traiderItemsInBase = null;
                for (int i = 0; i < 3; i++)
                {
                    traiderItemsInBase = new ConcurrentBag<TraiderItem>();
                    var baseFeesRounds = baseItems.Select(bi => Math.Round((double)bi.Fee * 0.4, 8)).ToArray();
                    Parallel.ForEach(traiderItems, traiderItem =>
                    {
                        double traiderFeeRound = Math.Round(traiderItem.Fee, 8);
                        for (var index = 0; index < baseItems.Count; index++)
                        {
                            var baseItem = baseItems[index];
                            if (traiderItem.DateUtc == baseItem.DateUtc && traiderFeeRound == baseFeesRounds[index])
                            {
                                traiderItemsInBase.Add(traiderItem);
                                break;
                            }
                        }
                    });
    
                    Console.WriteLine(i + "," + watch.ElapsedMilliseconds);
                }
    
                watch.Stop();
                Console.WriteLine("base:{0},traid:{1},res:{2},time:{3}", baseItems.Count, traiderItems.Count,
                    traiderItemsInBase.Count, watch.ElapsedMilliseconds);
            }
