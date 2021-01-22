    public static class Predicate {
        public static Func<T, bool> OrElse<T>(
                this Func<T, bool> lhs, Func<T, bool> rhs) {
            return lhs == null ? rhs : obj => lhs(obj) || rhs(obj);
        }
        public static Func<T, bool> AndAlso<T>(
                this Func<T, bool> lhs, Func<T, bool> rhs) {
            return lhs == null ? rhs : obj => lhs(obj) && rhs(obj);
        }
    }
    class Data {
        public string Color { get; set; }
    }
    class Program {
        static void Main() {
            bool redChecked = true, greenChecked = true; // from UI...
            List<Data> list = new List<Data>() {
                new Data { Color = "red"},
                new Data { Color = "blue"},
                new Data { Color = "green"},
            };
            Func<Data, bool> filter = null;
            if (redChecked) {
                filter = filter.OrElse(row => row.Color == "red");
            }
            if (greenChecked) {
                filter = filter.OrElse(row => row.Color == "green");
            }
            if (filter == null) filter = x => true; // wildcard
            var qry = list.Where(filter);
            foreach (var row in qry) {
                Console.WriteLine(row.Color);
            }
        }
    }
