    public class IntComparer : IComparer<string> {
        public int Compare(string x, string y) {
            if (x == null) {
                if (y == null) {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                } else {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            } else {
                // If x is not null...
                //
                if (y == null) {
                    // ...and y is null, x is greater.
                    return 1;
                } else {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    if (x.Length != y.Length) {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return x.Length - y.Length;
                    } else {
                        // compare numerically
                        int xInt = Int32.Parse(x);
                        int yInt = Int32.Parse(y);
                        return xInt - yInt;
                    }
                }
            }
        }
    }
