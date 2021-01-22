    public class Example
    {
      private Tile[] m_Array;
    
      public Tile this[int index]
      {
        get { return Interlocked.CompareExchange(ref m_Array[i], null, null); }
        set { Interlocked.CompareExchange(ref m_Array[i], value, m_Array[i]); }
      }
    }
