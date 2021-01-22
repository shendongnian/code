    var groups = from tc in sList 
                 group tc by tc.origURL into g 
                 orderby g.Count() 
                 select new { myLink = g.Key, Items = g }; 
    foreach(var group in groups) {
        Console.WriteLine("Link: {0}, Count: {1}", group.myLink, group.Items.Count());
        foreach(var item in group.Items) {
            Console.WriteLine(item.txtDesc);
        }
    }
   
