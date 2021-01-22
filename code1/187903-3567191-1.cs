    // This will not compile!
    public class SomeClass
    {
        string _someMember;
        public static string RemoveFromString()
        {
            int start, end;            
            // Some logic to figure out where to start and end
            return _someMember.Remove(start, end);
        }
    }
