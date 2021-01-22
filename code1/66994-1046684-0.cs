    public class SuperString
    {
        public SuperString(string s) { S = s; }
    
        public static implicit operator SuperString(string s)
        {
            return new SuperString(s);
        }
    
        public string S { get; private set; }
    
        public bool IsNot() { return String.IsNullOrEmpty(S); }
    }
    
    [TestMethod]
    public void Test_SuperString()
    {
        SuperString ss = "wee";
        SuperString xx = "";
        if (xx.IsNot()) ss = "moo";
        System.Console.WriteLine(ss.S);
    }
