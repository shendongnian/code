    namespace GenericMethodParameter
    {
        abstract class TestClass
        {
            abstract protected void myMethod<T>(List<T> myList);
        }
        class Program:TestClass
        {
    
    
            static void Main(string[] args)
            {
                Program program=new Program();
                program.myMethod<DateTime>(new List<DateTime>(){DateTime.Now});
                Console.ReadKey();
            }
    
            protected override void myMethod<T>(List<T> myList)
            {
    
                string dateTime = ((DateTime)(object)myList[0]).ToString("dd-MM-yyyy");
    
                Console.WriteLine(dateTime);
                //throw new NotImplementedException();
            }
        }
    }
