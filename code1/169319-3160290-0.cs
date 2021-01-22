    public class Foo
    {
      private int m_Member;
    
      public override bool Equals(object obj)
      {
        // We use 'as' because we are not certain of the type.
        var that = obj as Foo;
        if (that != null)
        {
          return this.m_Member == that.m_Member;
        }
        return false;   
      }
    }
