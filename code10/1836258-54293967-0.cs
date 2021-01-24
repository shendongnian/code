    using (var session = Store.OpenSession(database))
    {
        var command = new GetDocumentsCommand(id, null, false);
        session.Advanced.RequestExecutor.Execute(command, session.Advanced.Context);
        var result = command.Result.Results.FirstOrDefault();
        var json = result?.ToString(); // At this point you already have your JSON
        var jObject = JObject.Parse(json);
        jObject.Remove("@metadata"); // If you don't want metadata in your JSON
        jObject.Add("Id", id); // Because Id does not appear to be part of JSON
        return jObject;
    }
