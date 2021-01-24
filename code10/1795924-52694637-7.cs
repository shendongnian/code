    public class TokenService
    {
        public Task SaveAccessToken(string accessToken) {
            return JSRuntime.Current.InvokeAsync<object>("wasmHelper.saveAccessToken",accessToken);
        }
        public Task<string> GetAccessToken() {
            return JSRuntime.Current.InvokeAsync<string>("wasmHelper.getAccessToken");
        }
    }
