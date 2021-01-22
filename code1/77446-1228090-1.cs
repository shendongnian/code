    private class FooPrinter : IFooWrapperUser<string> {
        public string Apply<T>(IFooWrapper<T> wrapper) {
            return wrapper.Foo.ToString();
        }
    }
    ...
        IFooWrapperUser<string> user = new FooPrinter();
        foreach (IExistFooWrapper wrapper in list) {
            System.Console.WriteLine(wrapper.Apply(user));
        }
    ...
