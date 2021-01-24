    internal class IntegerExtensions {
        public static int Sum(this int i, List<object> objects) {
            int sum = 0;
            foreach (object o in objects) {
                int val = 0;
                if (int.TryParse(o.ToString(), out val))
                    sum += val;
            }
            return sum;
        }
    }
    // Usage:
    int sum = int.Sum(myObjects);
