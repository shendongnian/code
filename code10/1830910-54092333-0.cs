    class Program
    {
        static void Main(string[] args)
        {
            // Your categires been passed to the method (new categories I assume)
            List<int> categories = new List<int>();
            // Updated categores you retrieved from the database.
            ObservableCollection<int> updatedCategories  = new ObservableCollection<int>();
            // Select all the none matching categires to be added in the <mapper.Map>
            var notmatching = (from u in updatedCategories  join n in categories on u equals n where !Comparer(u, n) select u).ToList();
            
            // Select all the matching categires to be added in the <categories> collection
            var matching = (from u in updatedCategories  join n in categories on u equals n where Comparer(u, n) select u).ToList();
            // Addiing notmaching categories to you map
            notmatching.ForEach(i => Map(i));
            
            // Adding matching categies to your existing Categories collection
            categories.AddRange(matching);
        }
        static bool Comparer(int a, int b) {
            return a == b;
        }
        static void Map(int a) {
        }
    }
