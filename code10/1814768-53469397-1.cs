    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataClass {
                PropertyOne = "Lorem",
                PropertyTwo = "Ipsum",
                Child = new ChildClass {
                    PropertyThree = "Dolor"
                }
            };
            var data2 = new DataClass {
                PropertyOne = "lorem",
                PropertyTwo = "ipsum",
                Child = new ChildClass {
                    PropertyThree = "doloreusement"
                }
            };
            var dataList = new List<DataClass>() { data, data2 };
            IEnumerable<DataClass> results = dataList.Where( d => d.SelectedFields.MatchIgnoreCase( d, "lorem").Any());
            foreach (DataClass source in results) {
                Console.WriteLine(source.ToString());
            }
            Console.ReadKey();
        }
    }
