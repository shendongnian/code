    public static class NumberExtensionMethods
    {
        public static bool IsBetween(this long value, long Min, long Max)
        {
            if (value >= Min && value <= Max) return true;
            else return false;
        }
    }
...
    // Checks if this number is between 1 and 100.
    long MyNumber = 99;
    MessageBox.Show(MyNumber.IsBetween(1, 100));
