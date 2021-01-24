    @using Microsoft.JSInterop;
     <a href="#" class="btn btn-primary" onclick="@GoSomewhere">Go somewhere with Blazor</a>
    @functions {
        protected void GoSomewhere()
        {
            RedirectTo("/FetchData");  //or any other "page" in your pages folder
        }
        public static Task<string> RedirectTo(string path)
        {
            return JSRuntime.Current.InvokeAsync<string>(
                "clientJsfunctions.RedirectTo", path);
        }    
    }
