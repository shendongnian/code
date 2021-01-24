    class Program
    {
        static void Main(string[] args)
        {
            List<testClass> ogList = new List<testClass>();
            bool testCondition = true;
            //use the select to update and project to new collection
            var updated =
                ogList 
                .Select(x =>
                {
                    if (testCondition)
                        x.testProp = 1;
                    return x;
                }).ToList();
            //use the foreach to update original collection
            ogList.ForEach(x =>
            {
                if (testCondition)
                    x.testProp = 1;
            });
        }
    }
    public class testClass
    {
        public int testProp { get; set; }
    }
