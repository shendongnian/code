    internal class Extensions {
        public static double Sum(this List<object> objects) {
            double sum = 0;
            foreach (object o in objects) {
                double val = 0;
                if (double.TryParse(o.ToString(), out val))
                    sum += val;
            }
            return sum;
        }
    }
    // Usage:
    double sum = myObjects.Sum();
