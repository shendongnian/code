    public class BlazorExtensionScripts : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
    
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "script");
            builder.AddContent(1, "Blazor.registerFunction('Focus', (controlId) => { document.getElementById(controlId).focus(); });");
            builder.CloseElement();
        }
        public static void Focus(string controlId)
        {
             RegisteredFunction.Invoke<object>("Focus", controlId);
        }
    }
