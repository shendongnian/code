    public class MyHashtable : Hashtable
    {
        public override int GetHashCode()
        {
            // return a different hashcode here!
            return base.GetHashCode();
        }
    }
