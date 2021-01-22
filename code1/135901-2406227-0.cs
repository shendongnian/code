    public class MyCredentials : ClientCredentials
    {
        public override void ApplyClientBehavior(ServiceEndpoint endpoint,
            ClientRuntime behavior)
        {
            // Assuming GetCertificateFromNetwork retrieves from CDS
            ClientCertificate.Certificate = GetCertificateFromNetwork();
        }
        protected override ClientCredentials CloneCore()
        {
            // ...
        }
    }
