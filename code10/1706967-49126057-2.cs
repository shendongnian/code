    container.RegisterConditional<IDataReader, DataReaderImpl>(
        c => c.Consumer?.ImplementationType == typeof(LineageIdDecorator) 
            || c.Consumer?.Target.Name.StartsWith("original") == true);
    container.RegisterConditional<IDataReader, LineageIdDecorator>(
        c => c.Consumer?.Target.Name.StartsWith("decorated") == true);
    container.RegisterConditional<IDataReader, RuntimeDecoratorSelector>(c => !c.Handled);
            
