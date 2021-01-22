    public class IdSearcher
    {
         private int m_Id; // captures the state...
         public IdSearcher( int id ) { m_Id = id; }
         public bool TestForId( in otherID ) { return m_Id == otherID; }
    }
    // other code somewhere...
    public void GetRecord(int id)
    {
        var srchr = new IdSearcher( id );
        _myentity.Schedules.Where( srchr.TestForId );
    }
    
    
