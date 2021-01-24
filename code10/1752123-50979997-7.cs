    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    
    namespace AspNetCorePlayground.Models
    {
        public class MyFirstModelBinderTest
        {
            [ModelBinder(BinderType = typeof(MyFirstModelBinder))]
            public decimal SomeDecimal { get; set; }
        }
    }
