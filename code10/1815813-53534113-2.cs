            //
        // Summary:
        //     Gets or sets the non-service arguments to pass to the Microsoft.AspNetCore.Mvc.TypeFilterAttribute.ImplementationType
        //     constructor.
        //
        // Remarks:
        //     Service arguments are found in the dependency injection container i.e. this filter
        //     supports constructor injection in addition to passing the given Microsoft.AspNetCore.Mvc.TypeFilterAttribute.Arguments.
        public object[] Arguments { get; set; }
