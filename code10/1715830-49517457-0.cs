    public class MyList : StaticPagedList<OverdueUpcomingInvoiceViewModel>
    {
         public MyList() : base(new OverdueUpcomingInvoiceViewModel[] { }, 1, 1, 0)
         {
         }
    }
