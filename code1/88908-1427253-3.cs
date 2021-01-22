            var total = 0;
            using(StreamReader sr=new StreamReader("log.log"))
            {
                
                while (!sr.EndOfStream)
                {
                    var counts = sr
                        .ReadLine()
                        .Split(' ')
                        .GroupBy(s => s)
                        .Select(g => new{Word = g.Key,Count = g.Count()});
                    var wc = counts.SingleOrDefault(c => c.Word == "you");
                    total += (wc == null) ? 0 : wc.Count;
                }
            }
