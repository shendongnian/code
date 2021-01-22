    public abstract class AbstractData
    {
        public abstract string SomeValue { get; set; }
        public abstract bool ReadOnly { get; set; }
        //etc.
    }
    public interface IDataProvider
    {
        AbstractData Get(object id);
    }
    public class LegacyData : AbstractData
    {
         // Implement AbstractData, and
         public long Id { get { return m_Id; } set { m_Id = value; };
         private long m_Id;
    }
    public class LegacyDataNHibernateProvider : IDataProvider
    {
         public LegacyDataProvider()
         {
             // Set up fluent nhibernate mapping 
         }
         public AbstractData Get(object id)
         {
               // Interpret id as legacy identifier, retrieve LegacyData item, and return
         }
    };
    // Same again for new data provider
