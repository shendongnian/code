    public partial class myDataContext
    {
           public IQueryable<Boxer> IsProspect()
           {
                 return from tBoxer in myDataContext.tBoxer 
                        where tBoxer.IsProspect == true             
                        select tBoxer;
           }
    }
