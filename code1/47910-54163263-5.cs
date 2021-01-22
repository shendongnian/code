    public class Example
    {
        public IEnumerator<string> DoSomething()
        {
            const int start = 1;
            const int stop = 42;
            for (var index = start; index < stop; index++)
            {
                yield return index % 2 == 0 ? "even" : "odd";
            }
        }
    } 
