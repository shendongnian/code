    static void Main(String[] args) 
    {
        int n = int.Parse(Console.ReadLine());
        var data = new List<(int, string)>(n);
        for(int a0 = 0; a0 < n; a0++)
        {
            var tokens = Console.ReadLine().Split(' ');
            int x = int.Parse(tokens[0]);
            string s = tokens[1];
          
            if(a0 < n/2) s = "-";
           data.Add( (val: x, str: s) );
        }
        
        foreach(var item in data.OrderBy(i => i.val))
        {
            Console.Write(item.str + " ");
        }
    }
