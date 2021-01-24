        JsonSerializer DynamicDataJsonSerializer;
        DynamicDataJsonSerializer = JsonSerializer.Create(JsonConverterSetup.GetTransparentSerializerSettings());
    
        MyClass dataToSaveToMogo;
        var dataToSaveToMogoAsDynamic = DynamicDataJsonSerializer.Deserialize<ExpandoObject>(DynamicDataJsonSerializer.Serialize(dataToSaveToMogo));
