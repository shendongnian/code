    abstract class SuperClass
    {
        protected bool HasContentImpl(int chapterID, int institution)
        {
            Database db = new Database();
            int result;
            if (institution >= 0) // assuming negative numbers are out of range
                result = db.ExecuteSpRetVal(chapterID, institution);
            else
                result = db.ExecuteSpRetVal(chapterID);
            return result > 0;
        }
    }
    class SubClass1 : SuperClass
    {
        public bool HasContent(int chapterID)
        {
            return base.HasContentImpl(chapterID, -1);
        }
    }
    class SubClass2 : SuperClass
    {
        public bool HasContent(int chapterID, int institution)
        {
            return base.HasContentImpl(chapterID, institution);
        }
    }
