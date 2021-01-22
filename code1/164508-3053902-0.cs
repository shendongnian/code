        public class MsSql2005Dialect : NHibernate.Dialect.MsSql2005Dialect
    {
        public MsSql2005Dialect()
        {
            RegisterFunction("getDate",
                new NoArgSQLFunction("convert(datetime, floor(convert(float, getdate())))", NHibernateUtil.DateTime, false));
            RegisterFunction("getDateTime",
                new NoArgSQLFunction("getdate", NHibernateUtil.DateTime, true));
        }
    }
