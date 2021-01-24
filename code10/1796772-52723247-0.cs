    using AutoMapper;
    namespace ConsoleApp39
    {
        class Program
        {
            static void Main (string[] args)
            {
                // fill list1 with data
                var list1 = new List1
                {
                    Field1 = "test",
                    Field2 = 5,
                    Field3 = false,
                };
                // 1) configure auto mapper
                Mapper.Initialize (cfg => cfg.CreateMap<List1, List2> ());
                // 2) create list2 and fill with data from list1
                List2 list2 = Mapper.Map<List2> (list1);
                // fill extra fields
                list2.Field4 = new byte[] { 1, 2, 3 };
            }
        }
        public class List1
        {
            public string Field1 { get; set; }
            public int    Field2 { get; set; }
            public bool   Field3 { get; set; }
        }
        public class List2
        {
            public string Field1 { get; set; }
            public int    Field2 { get; set; }
            public bool   Field3 { get; set; }
            public byte[] Field4 { get; set; } // extra field
        }
    }
