       class Program
        {
            static void Main(string[] args)
            {
                List<Survey> surveys = new List<Survey>() {
                    new Survey() { ID = 1, Survey_Id = "Apple_Survey", Answer = 1,  User = "Jones"},
                    new Survey() { ID = 2, Survey_Id = "Apple_Survey", Answer = 1,  User = "Smith"},
                    new Survey() { ID = 3, Survey_Id = "Banana_Survey", Answer = 2,  User = "Smith"},
                    new Survey() { ID = 4, Survey_Id = "Apple_Survey", Answer = 3,  User = "Jane"},
                    new Survey() { ID = 5, Survey_Id = "Banana_Survey", Answer = 2,  User = "John"}
                };
                var results = surveys.GroupBy(x => x.Survey_Id).Select(x => x.GroupBy(y => y.Answer)
                    .Select(y => new { answer = y.Key, count = y.Count(), users = y.Select(z => z.User).ToList()}).ToList())
                    .ToList();
            }
        }
        public class Survey
        {
            public int ID { get; set; }
            public string Survey_Id { get; set; }
            public int Answer { get; set; }
            public string User { get; set; }
        }
