    class Factory
    {
         Dictionary test = new Dictionary(string, Func<ICreate>);
         public FactoryMethod()
         {
            test.Add("classA", () => new a());
            test.Add("classB", () => new b());
            test.Add("classC", () => new c());
         }
         public ICreate Create(string toMatch)
         {
            var creationFunction = test[toMatch];
            return creationFunction();
         }
    }
