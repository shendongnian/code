            var l = new List<int>();
            l.Add(0);
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Add(6);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] % 2 == 0)
                {
                    l.RemoveAt(i);
                    i--;
                }
            }
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
