    public class ThingBuilder
    {
       // set up defaults so that we don't need to set them unless required
       private string m_bongoName = "some name";
       private DateTime m_dateTime = new DateTime(2001, 1, 1);
       private int m_anotherArg = 5;
       private bool m_isThisIsGettingTedious = true;
    
       public ThingBuilder BongoName(string bongoName)
       {
          m_bongoName = bongoName;
          return this;
       }
    
       public ThingBuilder DateTime(DateTime dateTime)
       {
          m_dateTime = dateTime;
          return this;     
       }
    
       // etc. for properties 3...N
    
       public Thing Build()
       {    
          return new Thing(m_bongoName, m_dateTime, m_anotherArg, m_isThisGettingTedious);
       }
    }
