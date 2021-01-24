    public class test
        {
            public int id { get; set; }
            public int globalId { get; set; }
            public string taskStatus { get; set; }
        }
        public void SampleName()
        {
            List<test> testList = new List<test>()
            {
                new test() { id = 1, globalId =  10, taskStatus =  "New"},
                new test() { id = 2 , globalId = 11 , taskStatus = "New"},
                new test() { id = 3 , globalId = 10 , taskStatus = "InProgress"},
                new test() { id = 4 , globalId = 12 , taskStatus = "New"}
            };
            var result = testList.Where(q => testList.Count(a => a.globalId == q.globalId) == 1 && q.taskStatus != "InProgress" && q.id < 4).ToList();
        }
