    using (var ctx = new MyContext()){
    try{
    // worker thread id =  n
    SomeDto dto= await ctx.SomeDtoSet.Where(x => x.SomeDto Id == id).SingleOrDefaultAsync();
    // worker thread id =  n + 1
    ctx.SaveChangesAsync();
    catch (ThreadAbortException ex)
    {
    Thread.ResetAbort();
    }}
    
    
