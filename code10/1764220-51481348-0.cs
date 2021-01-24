    //need to add "using Microsoft.AspNetCore.Mvc.Formatters;"
    services.AddMvc(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.InputFormatters.Add(new XmlSerializerInputFormatter());
        config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    });
