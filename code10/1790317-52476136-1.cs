    namespace MySQL_3 {
        class Program {
            static void Main(string[] args) {
                var db = new myEntities();
    
                var test = db.ticket.Select(t => t.change_time.YearWeek(3).Insert(5, 0, "/"));
    
                var test2 = test.ToList();
    
                Console.Read();
            }
        }
    
        public static class BuiltInFunctions {
    
            [DbFunction("myModel.Store", "YEARWEEK")]
            public static string YearWeek(this DateTime date, Int32 mode) => throw new NotSupportedException("Direct calls are not supported.");
    
            [DbFunction("myModel.Store", "INSERT")]
            public static string Insert(this string str, int position, int number, string substr) => throw new NotSupportedException("Direct calls are not supported.");
        }
    }
