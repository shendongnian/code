    static class Program
    {
        static IEnumerator<Foo> GetBase() {
            yield return new Foo();
            yield return new Bar();
        }
        static IEnumerator<Bar> GetDerived()
        {
            return (IEnumerator<Bar>)GetBase();
        }
        static void Main()
        {
            var obj = GetDerived(); // EXCEPTION
        }
    }
