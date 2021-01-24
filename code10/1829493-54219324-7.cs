    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor.Components;
    using Microsoft.JSInterop;
    
    namespace MyApp.Web.App.Shared
    {
        public class MycomponentBase : BlazorComponent
        {
            public static Task<string> RedirectTo(string path)
            {
                return JSRuntime.Current.InvokeAsync<string>(
                    "clientJsfunctions.RedirectTo", path);
            }
        }
    }
