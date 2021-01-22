                var allItems = new List<SomeClass>();
            for (int i = 0; i < 10000000; i++)
                allItems.Add(new SomeClass() { id = i });
            Console.WriteLine("Tests Started");
            var timer = new Stopwatch();
            timer.Start();
            var filtered = new List<SomeClass>();
            foreach (var item in allItems)
                if (item.id != 9999)
                    filtered.Add(item);
            var y = filtered.Last();
            timer.Stop();
            Console.WriteLine("Transfer to filtered list: {0}", timer.Elapsed.TotalMilliseconds);
            timer.Reset();
            timer.Start();
            filtered = new List<SomeClass>(allItems);
            for (int i = 0; i < filtered.Count; i++)
                if (filtered[i].id == 9999)
                    filtered.RemoveAt(i);
            var s = filtered.Last();
            timer.Stop();
            Console.WriteLine("Removal from filtered list: {0}", timer.Elapsed.TotalMilliseconds);
            timer.Reset();
            timer.Start();
            var linqresults = allItems.Where(x => (x.id != 9999));
            var m = linqresults.Last();
            timer.Stop();
            Console.WriteLine("linq list: {0}", timer.Elapsed.TotalMilliseconds);
