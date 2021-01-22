    abstract class SuperClass
    {
        public abstract bool HasContent(int chapterID);
    }
    class SubClass1 : SuperClass
    {
        public override bool HasContent(int chapterID)
        {
            // write your implementation here
            return false;
        }
    }
    class SubClass2 : SuperClass
    {
        public override bool HasContent(int chapterID)
        {
            return HasContent(chapterID, 0); // assuming 0 as a default value
        }
        public bool HasContent(int chapterID, int institution)
        {
            // write your implementation here
            return false;
        }
    }
