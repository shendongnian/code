    class Program
    {
        static void Main(string[] args)
        {
            ServiceFactory factory = new ServiceFactory(false);
            //first call hits the webservice
            GetServiceQuestions(factory);
            //hists the cache next time
            GetServiceQuestions(factory);
            //can refresh on demand
            factory.ResetCache = true;
            GetServiceQuestions(factory);
            Console.Read();
        }
        //where the call to the "service" happens
        private static List<Question> GetServiceQuestions(ServiceFactory factory)
        {
            var myFirstService = factory.GetSATService();
            var firstServiceQuestions = myFirstService.GetAllQuestions();
            foreach (Question question in firstServiceQuestions)
            {
                Console.WriteLine(question.Text);
            }
            return firstServiceQuestions;
        }
    }
    //this stands in place of your xml file
    public static class DataStore
    {
        public static List<Question> Questions;
    }
    //a simple question
    public struct Question
    {
        private string _text;
        public string Text { get { return _text; } }
        public Question(string text)
        {
            _text = text;
        }
    }
    //the contract for the real and fake "service"
    public interface ISATService
    {
        List<Question> GetAllQuestions();
    }
    //hits the webservice and refreshes the store
    public class ServiceWrapper : ISATService
    {
        public List<Question> GetAllQuestions()
        {
            Console.WriteLine("From WebService");
            //this would be your webservice call
            DataStore.Questions = new List<Question>()
                       {
                           new Question("How do you do?"), 
                           new Question("How is the weather?")
                       };
            //always return from your local datastore
            return DataStore.Questions;
        }
    }
    //accesses the data store for the questions
    public class FakeService : ISATService
    {
        public List<Question> GetAllQuestions()
        {
            Console.WriteLine("From Fake Service (cache):");
            return DataStore.Questions;
        }
    }
    //The object that decides on using the cache or not
    public class ServiceFactory
    {
        public  bool ResetCache{ get; set;}
        public ServiceFactory(bool resetCache)
        {
            ResetCache = resetCache;
        }
        public ISATService GetSATService()
        {
            if (DataStore.Questions == null || ResetCache)
                return new ServiceWrapper();
            else
                return new FakeService();
        }
    }
