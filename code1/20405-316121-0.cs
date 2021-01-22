    IEnumerable<string> letters = new[]{
                    "A","B","C","D","E","F",                       
                    "G","H","I","J","K","L",
                    "M","N","O","P","Q","R","S",           
                    "T","U","V","W","X","Y","Z"};
    
    var result = Enumerable.Range(0, 4)
                    .Aggregate(letters, (curr, i) => curr.SelectMany(s => letters, (s, c) => s + c));
    
    foreach (var val in result)
         Console.WriteLine(val);
