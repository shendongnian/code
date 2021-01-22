    public class C1 {
      private Dictionary<string,object> m_bag = new Dictionary<string,object>();
      public string Name {
        get { return (string)m_bag["Name"]; }
        set { m_bag["Name"] = value; }
      }
      ...
    }
