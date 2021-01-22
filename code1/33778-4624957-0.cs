    ...
    using System.Web.Routing;
    ...
    class Program
    {
        static void Main(string[] args)
        {
    
            object anonymous = CallMethodThatReturnsObjectOfAnonymousType();
            //WHAT DO I DO WITH THIS?
            //I know! I'll use a RouteValueDictionary from System.Web.dll
            RouteValueDictionary rvd = new RouteValueDictionary(anonymous);
            Console.WriteLine("Hello, my name is {0} and I am a {1}", rvd["Name"], rvd["Occupation"]);
        }
    
        private static object CallMethodThatReturnsObjectOfAnonymousType()
        {
            return new { Id = 1, Name = "Peter Perhac", Occupation = "Software Developer" };
        }
    }
