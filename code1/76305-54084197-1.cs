    public class SampleClass()
    {
        public void SampleMethod()
        {
            Console.WriteLine(Props.MethodName());     //consoleOutput: SampleMethod
        }
        
        public string SomeVar
        {
            get
            {
                Console.WriteLine(Props.PropName());   //consoleOutput: SomeVar
                
                Console.WriteLine(Props.MethodName()); //consoleOutput: get_SomeVar
            }
        }
    }
