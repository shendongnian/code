    public class PrivateFunction
    {
        private int _age;
        public PrivateFunction(int age)
        {
            _age = age;
        }
        private int DoSomethingPrivate(string parameter)
        {
            Debug.WriteLine($"Parameter: {parameter}, Age: {_age}");
            return _age;
        }
    }
