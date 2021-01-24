    public void ConfigureServices(IServiceCollection services)
    {
       services.AddMvc(options =>
                    {
                        options .OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                        options .InputFormatters.Add(new XmlDataContractSerializerInputFormatter(options ));
                        //more output formatters
                        var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                        if (jsonOutputFormatter != null)
                        {
            
       jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.myvendormediatype");                 
      
                        }
                    }
    }
