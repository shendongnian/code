    public class ExampleMessageA : IMessage
    {
    };
    
    public class ExampleMessageB : IMessage
    {
    };
    public class ExampleComponent : IComponent
    {
        [Handles(typeof(ExampleMessageA))]
        public void HandleMessageA(ExampleMessageA message)
        {
            Console.WriteLine(string.Format("Handling message of type ExampleMessageA: {0}", message.GetType().FullName));
        }
        
        [Handles(typeof(ExampleMessageB))]
        public void HandleMessageB(ExampleMessageB message)
        {
            Console.WriteLine(string.Format("Handling message of type ExampleMessageB: {0}", message.GetType().FullName));
        }
        [Handles(typeof(ExampleMessageA))]
        public void HandleMessageA_WrongType(object foo)
        {
            Console.WriteLine(string.Format("HandleMessageA_WrongType: {0}", foo.GetType().FullName));
        }
        [Handles(typeof(ExampleMessageA))]
        public void HandleMessageA_MultipleArgs(object foo, object bar)
        {
            Console.WriteLine(string.Format("HandleMessageA_WrongType: {0}", foo.GetType().FullName));
        }
    }
