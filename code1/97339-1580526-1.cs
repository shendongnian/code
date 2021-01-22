    public partial class Test
    {
        public Test()
        {
             //do stuff
 
             DoExtraStuff();
        }
        partial void DoExtraStuff();
    }
    public partial class Test // in some other file
    {
         partial void DoExtraStuff()
         {
             // do more stuff
         }
    }
