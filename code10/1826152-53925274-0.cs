    public class MonthsFilter : FilterDefinition
    {
        public MonthsFilter()
        {
            WithName("MonthsFilter")
                .AddParameter("startMonths", NHibernateUtil.Int32)
                .AddParameter("endMonths", NHibernateUtil.Int32);
        }
    }
