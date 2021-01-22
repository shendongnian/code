    using AutoMapper;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Foo {Value = "Abc"};
            var destination = Mapper.DynamicMap<FooViewModel>(source);
            Debug.Assert(source.Value == destination.Value);
        }
    }
    public class Foo
    {
        public string Value { get; set; }
    }
    public class FooViewModel
    {
        public string Value { get; set; }
    }
