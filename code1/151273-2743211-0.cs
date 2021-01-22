    public class MagicStringsTest
    {
        public static void Main(string[] args)
        {
            SemiNiceClass semiNice = new SemiNiceClass();
            // The user wants to do:  semiNice.notSoNice.y = 50;
            
            semiNice.Write( t=>t.y , 50);
            Console.ReadLine();
        }
    }
    public class SemiNiceClass
    {
        public NotSoNiceClass notSoNice { get; set; }
        public int z { get; set; }
        public SemiNiceClass()
        {
            notSoNice = new NotSoNiceClass();
        }
        public void Write<R>(Expression<Func<NotSoNiceClass,R>> exp, R value)
        {
            if (exp.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression e = exp.Body as MemberExpression;
                Console.WriteLine("Writing value for " + e.Member.Name 
                    + " of NotSoNiceClass");
                FieldInfo info = e.Member as FieldInfo;
                // value is set using reflection...
                info.SetValue(notSoNice, value);
            }
            else
            {
                // throw exception, expecting of type x=>x.y
            }
        }
     
    }
