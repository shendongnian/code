    static void Main(string[] args)
    {
        var src = new PagedCollectionResultDTO<ExampleDTO>();
        src.Data = new List<ExampleDTO>{
            new  ExampleDTO{ Field1 = 1, Field2 = 2 }
        };
        var adapter = new TypeAdapter();
        var result = adapter.Adapt(src, AdaptExampleDTO);
    }
    public static ExampleModel AdaptExampleDTO(ExampleDTO source)
    {
        if (source == null) return null;
        var target = new ExampleModel()
        {
            Field1 = source.Field1,
            Field2 = source.Field2
        };
        return target;
    }
