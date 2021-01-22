    [COMVisible(true)]
    public class CollectionOfStrings
    {
      IEnumerator<string> m_enum;
      int m_count;
    
      public CollectionOfStrings(IEnumerable<string> list)
      { 
        m_enum = list.GetEnumerator();
        m_count = list.Count;
      }
    
      public int HowMany() { return m_count; }
    
      public bool MoveNext() { return m_enum.MoveNext(); }
    
      public string GetCurrent() { return m_enum.Current; }
    }
