    public class ExampleModel : IExampleModel<ExampleDTO>
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }
        public void Adapt(ExampleDTO source)
        {
            Field1 = source.Field1;
            Field2 = source.Field2;
        }
    }
