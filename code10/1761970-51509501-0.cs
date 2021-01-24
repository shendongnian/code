    using System;
    using System.Text;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Cryptography;
    using Microsoft.SharePoint.Client;
    
    namespace PnpTest {
    
      class ClientAssertionCertificate : IClientAssertionCertificate {
    
        X509Certificate2 certificate;
        public string ClientId { get; private set; }
    
        public string Thumbprint {
          get {
            return Base64UrlEncoder.Encode(certificate.GetCertHash());
          }
        }
    
        public ClientAssertionCertificate(string clientId, X509Certificate2 certificate) {
          ClientId = clientId;
          this.certificate = certificate;
        }
    
        public byte[] Sign(string message) {
          using (var key = certificate.GetRSAPrivateKey()) {
            return key.SignData(Encoding.UTF8.GetBytes(message), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
          }
        }
      }
    
      class Program {
        static void Main(string[] args) {
          string siteUrl = "https://xxxxxxxxxxxxxxx.sharepoint.com";
          string clientId = "xxxxxxxxxxxxxxx";
          string tenant = "xxxxxxxxxxxxxxx.onmicrosoft.com";
          string certificatePath = "resources/xxxxxxxx.pfx";
          string certificatePassword = "xxxxxxxx";
    
          var certfile = System.IO.File.OpenRead(certificatePath);
          var certificateBytes = new byte[certfile.Length];
          certfile.Read(certificateBytes, 0, (int)certfile.Length);
          var certificate = new X509Certificate2(
              certificateBytes,
              certificatePassword,
              X509KeyStorageFlags.Exportable |
              X509KeyStorageFlags.MachineKeySet |
              X509KeyStorageFlags.PersistKeySet);
          
          var clientAssertionCertificate = new ClientAssertionCertificate(clientId, certificate);
    
          string authority = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/", "https://login.windows.net", tenant);
    
          var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
    
          var host = new Uri(siteUrl);
    
          using (var clientContext = new ClientContext(siteUrl)) {
            clientContext.ExecutingWebRequest += (sender, webRequestArgs) => {
              var arFuture = authContext.AcquireTokenAsync(host.Scheme + "://" + host.Host + "/", clientAssertionCertificate);
              var ar = arFuture.Result;
    
              webRequestArgs.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + ar.AccessToken;
            };
            clientContext.Load(clientContext.Web, p => p.Title);
            clientContext.ExecuteQuery();
            Console.WriteLine(clientContext.Web.Title);
          }
        }
      }
    }
