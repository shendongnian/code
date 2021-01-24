    using Microsoft.JSInterop;
    
        public class ExampleJsInterop
        {
            public static Task<string> Prompt(string message)
            {
                // Implemented in exampleJsInterop.js
                return JSRuntime.Current.InvokeAsync<string>(
                    "exampleJsFunctions.showPrompt",
                    message);
            }
        }
