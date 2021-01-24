    public OutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
    }
    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var responseData = Encoding.UTF8.GetBytes(LoadSchema(context));
        return response.Body.WriteAsync(responseData, 0, responseData.Length);
    }
    private string LoadSchema(OutputFormatterWriteContext context)
    {
        var schema = new List<SchemaModel>();
        var returnData = new ReturnModel();
        foreach (var Field in (context.Object as IEnumerable<dynamic>).FirstOrDefault().GetType().GetProperties())
        {
            schema.Add(new SchemaModel
            {
                FieldName = Field.Name,
                DataType = Field.PropertyType.Name
            });
        }
        returnData.Schema = schema;
        returnData.ReturnData = context.Object;
        return JsonConvert.SerializeObject(returnData);
    }
