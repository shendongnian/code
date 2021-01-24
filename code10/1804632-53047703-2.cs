    var builder = new DataExtractor<MyTypeWith100Properties>();
    // will output 
    // x => x.Property1          
    builder.WithProperty(x => x.Property1);
    // will output 
    // x => x.Property2
    builder.WithProperty(x => x.Property2);
    // will output 
    // Param0 => Param0.Property1
    // Param0 => Param0.Property2
    var b = builder.WithAllProperties<MyTypeWith100Properties>();
