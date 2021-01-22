    using String = JDanielSmith.String;
    namespace Foo.Bar.Baz
    {
    	class Program
    	{
    		static void test(string myString)
    		{
    			if (String.IsNullOrBlank(myString))
    			{
    				throw new ArgumentException("Blank strings cannot be handled.");
    			}
    		}
    ...
