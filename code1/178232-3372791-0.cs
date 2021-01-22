    namespace MEF_Interface
    {
        // Interface to recognize the concrete implementation as
        public interface IMessageWriter
        {
            void WriteMessage();
        }
    
    }
    namespace MEF_HelloMessageWriter
    {
        // Concrete implementation in another assembly
        [Export(typeof(IMessageWriter))]
        public class HelloMessageWriter : IMessageWriter
        {
            public void WriteMessage() { Console.WriteLine("Hello!"); }
        }
    }
    namespace MEF_GoodbyeMessageWriter
    {
        // Concrete implementation in another assembly
        [Export(typeof(IMessageWriter))]
        public class GoodbyeMessageWriter : IMessageWriter
        {
            public void WriteMessage() { Console.WriteLine("Goodbye!"); }
        }
    }
    namespace MEF_Example
    {
        class DIContainer
        {
            [Import]
            public IMessageWriter MessageWriter { get; set; }
            public DIContainer(string directory)
            {
                // No more messy XML DI definition, just a catalog that loads
                // all exports in a specified directory. Filtering is also available.
                DirectoryCatalog catalog = new DirectoryCatalog(directory);
                catalog.Refresh();
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string helloMessageWriterPath =
                    @"C:\shared\Projects\MEF_Example\MEF_HelloMessageWriter\bin\Debug";
    
                string goodbyeMessageWriterPath =
                    @"C:\shared\Projects\MEF_Example\MEF_GoodbyeMessageWriter\bin\Debug";
    
                DIContainer diHelloContainer = new DIContainer(helloMessageWriterPath);
                diHelloContainer.MessageWriter.WriteMessage();
    
                DIContainer diGoodbyeContainer = new DIContainer(goodbyeMessageWriterPath);
                diGoodbyeContainer.MessageWriter.WriteMessage();
    
                Console.ReadLine();
            }
        }
    }
