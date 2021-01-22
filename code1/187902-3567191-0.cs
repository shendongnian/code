    // This will not compile!
    public class SomeClass
    {
        string _someMember;
        public static string RemoveFromString(int start, int end)
        {
            return _someMember.Remove(start, end);
        }
    }
