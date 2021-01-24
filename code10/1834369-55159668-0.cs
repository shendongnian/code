    if (filter.ExecutionId.HasValue)
    {
        Builder.Where("e.[Id] = @ExecutionId");
        ((DynamicParameters)SelectedQuery.Parameters)
            .AddDynamicParams(new {
                 ExecutionId = filter.ExecutionId.Value
             });
     }
