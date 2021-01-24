    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Schema;
    using Newtonsoft.Json.Schema.Generation;
    // json that contains properties with invalid values
    string json = @"{
      ""AlbumId"": -10,
      ""ArtistId"": 1,
      ""Title"": null,
      ""Price"": 200.0
    }";
    JsonTextReader reader = new JsonTextReader(new StringReader(json));
    JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader)
    {
        Schema = new JSchemaGenerator().Generate(typeof(Album))
    };
    var errors = new List<ValidationError>();
    validatingReader.ValidationEventHandler += (o, a) => errors.Add(new ValidationError
    {
        Property = a.ValidationError.Schema.Title,
        Message = a.ValidationError.Schema.Description,
        CurrentValue = a.ValidationError.Value
    });
    JsonSerializer serializer = new JsonSerializer();
    Album album = serializer.Deserialize<Album>(validatingReader);
    foreach (ValidationError error in errors)
    {
        Debug.WriteLine($"Property: {error.Property}, Message: {error.Message}");
    }
