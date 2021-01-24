    configuration.EnableSwagger(c =>
    {
         c.GroupActionsBy(apiDesc =>
         {
              var attribute = apiDesc.GetControllerAndActionAttributes<SwaggerControllerNameAttribute>();
              if (attribute.Any())
              {
                   return attribute.First().ControllerName;
              }
              else
              {
                   return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName;
              }
         });        
    }
