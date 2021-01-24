    public class MyObject
    {
        public int MyInt { get; set; }
        public ObservableCollection<string> MyStrings { get; set; }
        public double MyDouble { get; set; }
        public MyObject(int aInt, string aString, double aDouble)
        {
            MyStrings = new ObservableCollection<string>();
            string[] substrings = aString.Split('/');
            this.MyInt = aInt;
            foreach (string s in substrings)
            {
                MyStrings.Add(s);
            }
            this.MyDouble = aDouble;
        }
    }
