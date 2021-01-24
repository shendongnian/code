    public class SomeClass
    {
        public async void RunTask()
        {
            await SomeTask();
        }
        private Task<int> SomeTask()
        {
            var x = 10;
            System.Threading.Thread.Sleep(1000);
            return Task.FromResult(x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();
            someClass.RunTask();
        }
    }
