    async Task DoStuff()
    {
       var foos = GetFoosFromExternalSource();
       using(var ctx = new MyContext()
       {
           await ctx.Foos
               .UpsertRange(foos)
               .On(f => f.Property)
               .RunAsync();
           ctx.SaveChanges(); // not sure if savechanges call is necessary based on docu...
       }
    }
