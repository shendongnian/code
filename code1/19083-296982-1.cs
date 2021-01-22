    Interface IStringReference
    {
        void SetString(string value);
        string GetString();
    }
    class MyClass
    {
        public IStringReference TestIt()
        {
            ... details left out ;) ...
        }
    }
