    public class UpdateParametersAsRequired : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry s, ApiDescription a)
        {
            if (operation.OperationId == "ControllerName_Action")
            {
                if (operation.Parameters != null)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        if (parameter.Name == "ParameterYouWantToEdit")
                        { 
                            // You can edit the properties here
                            parameter.Required = true;
                        }
                    }
                }
                else
                {
                  // Add parameters if doesn't exists any
                    operation.Parameters = new List<IParameter>();
                    operation.Parameters.Add(
                        new Parameter
                        {
                            name = "ParameterName",
                            @in = "body",
                            @default = "123",
                            type = "string",
                            description = "x y z",
                            required = true
                        }
                    );
                }
            }
        }
    }
