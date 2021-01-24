    interface ISubSpaceFunction
    {
        int FunctionId { get; }
    }
    class Foo : ISubSpaceFunction
    {
        public int FunctionId => FooMethodForFunctionId();
        private int FooMethodForFunctionId()
        {
            //do foo function id stuff
            throw new NotImplementedException();//so it compiles
        }
    }
    class Bar : ISubSpaceFunction
    {
        public int FunctionId => BarMethodForFunctionId();
        private int BarMethodForFunctionId()
        {
            //do bar function id stuff
            throw new NotImplementedException();//so it compiles
        }
    }
    static class MyClass
    {
        private static List<int> GetListFromIds(string idsString, IEnumerable<ISubSpaceFunction> subSpaceFunctions)
        {
            var ids = string.IsNullOrWhiteSpace(idsString) ?
                Enumerable.Empty<int>() :
                idsString.Split(new[] { ',' })
                         .Where(x => !string.IsNullOrWhiteSpace(x))
                         .Select(x => x.Trim())
                         .Select(int.Parse);
            var idSet = new HashSet<int>(ids);
            return subSpaceFunctions.Select(ssf => ssf.FunctionId)
                                    .Where(ids.Contains)
                                    .ToList();
        }
    }
    class Example
    {
        public void Test()
        {
            string ids = "1, 2, 3, 4, 5";
            var subSpaceFunctions = new ISubSpaceFunction[] { new Foo(), new Bar() };
            var results = MyClass.GetListFromIds(ids, subSpaceFunctions);
        }
    }
