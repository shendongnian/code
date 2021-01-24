    public class Person
    {
        private static int _counter;
    
        public string GetNewId()
        {
            int id = Interlocked.Increment(ref _counter);
            return $"ABC{id}";
        }
    }
