    /// Example of using a Boolean indexed property
    /// to manipulate a [Flags] enum:
    public class BindingFlagsIndexer
    {
      BindingFlags flags = BindingFlags.Default;
      public bool this[BindingFlags index]
      {
        get
        {
          return (this.flags & index) == index;
        }
        set( bool value )
        {
          if( value )
            this.flags |= index;
          else
            this.flags &= ~index;
        }
      }
      public BindingFlags Value 
      {
        get
        { 
          return flags;
        } 
        set( BindingFlags value ) 
        {
          this.flags = value;
        }
      }
    }
    public static class Class1
    {
      public static void Example()
      {
        BindingFlagsIndexer myFlags = new BindingFlagsIndexer();
        // Sets the flag(s) passed as the indexer:
        myFlags[BindingFlags.ExactBinding] = true;
        // Indexer can specify multiple flags at once:
        myFlags[BindingFlags.Instance | BindingFlags.Static] = true;
        // Get boolean indicating if specified flag(s) are set:
        bool flatten = myFlags[BindingFlags.FlattenHierarchy];
        // use | to test if multiple flags are set:
        bool isProtected = ! myFlags[BindingFlags.Public | BindingFlags.NonPublic];
      }
    }
