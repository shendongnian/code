    using System.Net;
    using System.Configuration;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Newtonsoft.Json;
    using System.Text;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request.");
    
        SecretRequest secretRequest = await req.Content.ReadAsAsync<SecretRequest>();
        
        if(string.IsNullOrEmpty(secretRequest.Secret))
            return req.CreateResponse(HttpStatusCode.BadRequest, "Request does not contain a valid Secret."); 
    
        log.Info($"GetKeyVaultSecret request received for secret {secretRequest.Secret}");        
    
        var serviceTokenProvider = new AzureServiceTokenProvider();
        
        var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(serviceTokenProvider.KeyVaultTokenCallback));            
    
        var secretUri = SecretUri(secretRequest.Secret);
        log.Info($"Key Vault URI {secretUri} generated");
        SecretBundle secretValue; 
        try
        {
          secretValue = await keyVaultClient.GetSecretAsync(secretUri);
        }
        catch(KeyVaultErrorException kex)
        {
            return req.CreateResponse(HttpStatusCode.NotFound, $"{kex.Message}");
        }
        log.Info("Secret Value retrieved from KeyVault.");
    
        var secretResponse = new SecretResponse {Secret = secretRequest.Secret, Value = secretValue.Value};
    
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent(JsonConvert.SerializeObject(secretResponse), Encoding.UTF8, "application/json")};
    
        
    }
    
    public class SecretRequest
    {
        public string Secret {get;set;}
    }
    
    public class SecretResponse
    {
        public string Secret {get; set;}
        public string Value {get; set;}
    }
    
    public static string SecretUri(string secret)
    {
       return $"{ConfigurationManager.AppSettings["KeyVaultUri"]}/Secrets/{secret}";
    }
