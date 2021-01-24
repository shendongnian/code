            var S2 = Stopwatch.StartNew();
            var temp = Tuple.Create(0.00, 0, 0);
            for (int i = 0; i < FHM.Count; i++)
            {
                for (int n = 0; n < i; n++)
                {
                    if (FHM[n].Item1 > FHM[i].Item1)
                    {
                        temp = FHM[i];
                        FHM[i] = FHM[n];
                        FHM[n] = temp;
                    }
                }
            }
            S2.Stop();
            Console.WriteLine("Ticks S2 ForLoop = " + S2.ElapsedTicks); // 4000 ElapsedTicks
            S2.Reset();
            S2.Start();
            FHM.Sort();
            S2.Stop();
            Console.WriteLine("Ticks S2 List.Sort(); = " + S2.ElapsedTicks); // 700000 ElapsedTicks
