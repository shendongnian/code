    using Microsoft.Extensions.DependencyInjection; // it's an extension method
    using (var scope = serviceProvider.CreateScope())
    {
       // in your new Scope, use the scope's ServiceProvider
       var service = scope.ServiceProvider.GetService<SomeService>();
    }
            
