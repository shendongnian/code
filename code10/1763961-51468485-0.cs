    var linhaTokeep = myList.Where(l =>
            l.GroupBy(i => i).ToDictionary(k => k.Key, k => k.ToArray()).All(v => v.Value.Length <= 2));    
                foreach (var b in linhaTokeep)
                {
                    Console.WriteLine(string.Join(',' ,b));
    
                } 
