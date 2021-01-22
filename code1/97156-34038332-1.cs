        // Fastest among seqs, but still 30x times slower than direct sum
        // 49 mops vs 37 mops for yield, or c.30% faster
        [Test]
        public void SingleSequenceStructForEach() {
            var sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            for (var i = 0; i < 100000000; i++) {
                foreach (var single in new SingleSequence<int>(i)) {
                    sum += single;
                }
            }
            sw.Stop();
            Console.WriteLine($"Elapsed {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Mops {100000.0 / sw.ElapsedMilliseconds * 1.0}");
        }
