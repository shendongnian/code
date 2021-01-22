    public class Test : IEquatable<Test>
    {
        public string result;
        public Test(string result) { this.result = result; }
        public bool Equals(Test other)
        {
            return result.Equals(other.result);
        }
        //No need to override Equals(object obj), GetHashCode()
    }
