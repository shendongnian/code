    internal class TestHeapCollection
    {
        //stackoverflowQuestion
        public bool IsSaved(int a)
        {
            var someList = new List<int> {a-1};
            /*
    
            processing data with local variables
            */
            return a <= 0 || IsSaved(someList[0]);
        }
    }
