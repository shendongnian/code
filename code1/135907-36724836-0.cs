    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel.Configuration;
    using System.Configuration;
    using System.ServiceModel.Description;
    
    namespace System.ServiceModel.Description
    {
        /// <summary>
        /// Uses a X509 certificate from disk as credentials for the client.
        /// </summary>
        public class ClientCertificateCredentialsFromFile : ClientCredentials
        {
            public ClientCertificateCredentialsFromFile(CertificateSource certificateSource, string certificateLocation)
            {
                if (!Enum.IsDefined(typeof(CertificateSource), certificateSource)) { throw new ArgumentOutOfRangeException(nameof(certificateSource), $"{nameof(certificateSource)} contained an unexpected value."); }
                if (string.IsNullOrWhiteSpace(certificateLocation)) { throw new ArgumentNullException(nameof(certificateLocation)); }
    
                _certificateSource = certificateSource;
                _certificateLocation = certificateLocation;
    
                ClientCertificate.Certificate = certificateSource == CertificateSource.EmbeddedResource ?
                    GetCertificateFromEmbeddedResource(certificateLocation)
                    : GetCertificateFromDisk(certificateLocation);
            }
    
            /// <summary>
            /// Retrieves a certificate from an embedded resource.
            /// </summary>
            /// <param name="certificateLocation">The certificate location and assembly information. Example: The.Namespace.certificate.cer, Assembly.Name</param>
            /// <returns>A new instance of the embedded certificate.</returns>
            private static X509Certificate2 GetCertificateFromEmbeddedResource(string certificateLocation)
            {
                X509Certificate2 result = null;
    
                string[] parts = certificateLocation.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2) { throw new ArgumentException($"{certificateLocation} was expected to have a format of namespace.resource.extension, assemblyName"); }
                string assemblyName = string.Join(",", parts.Skip(1));
    
                var assembly = Assembly.Load(assemblyName);
                using (var stream = assembly.GetManifestResourceStream(parts[0]))
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    result = new X509Certificate2(bytes);
                }
    
                return result;
            }
    
            /// <summary>
            /// Retrieves a certificate from disk.
            /// </summary>
            /// <param name="certificateLocation">The file path to the certificate.</param>
            /// <returns>A new instance of the certificate from disk</returns>
            private static X509Certificate2 GetCertificateFromDisk(string certificateLocation)
            {
                if (!File.Exists(certificateLocation)) { throw new ArgumentException($"File {certificateLocation} not found."); }
                return new X509Certificate2(certificateLocation);
            }
    
    
            /// <summary>
            /// Used to keep track of the source of the certificate. This is needed when this object is cloned.
            /// </summary>
            private readonly CertificateSource _certificateSource;
    
            /// <summary>
            /// Used to keep track of the location of the certificate. This is needed when this object is cloned.
            /// </summary>
            private readonly string _certificateLocation;
    
            /// <summary>
            /// Creates a duplicate instance of this object.
            /// </summary>
            /// <remarks>
            /// A new instance of the certificate is created.</remarks>
            /// <returns>A new instance of <see cref="ClientCertificateCredentialsFromFile"/></returns>
            protected override ClientCredentials CloneCore()
            {
                return new ClientCertificateCredentialsFromFile(_certificateSource, _certificateLocation);
            }
        }
    }
    
    
    namespace System.ServiceModel.Configuration
    {
        /// <summary>
        /// Configuration element for <see cref="ClientCertificateCredentialsFromFile"/>
        /// </summary>
        /// <remarks>
        /// When configuring the behavior an extension has to be registered first.
        /// <code>
        /// <![CDATA[
        /// <extensions>
        ///     <behaviorExtensions>
        ///         <add name = "clientCertificateCredentialsFromFile"
        ///             type="System.ServiceModel.Configuration.ClientCertificateCredentialsFromFileElement, Assembly.Name" />
        ///     </behaviorExtensions>
        /// </extensions>
        /// ]]>
        /// </code>
        /// Once the behavior is registered it can be used as follows.
        /// <code>
        /// <![CDATA[ 
        /// <behaviors>
        ///     <endpointBehaviors>
        ///         <behavior name = "BehaviorConfigurationName" >
        ///             <clientCertificateCredentialsFromFile fileLocation="C:\certificates\paypal_cert.cer" />
        ///         </behavior>
        ///     </endpointBehaviors>
        /// </behaviors>
        /// <client>
        ///     <endpoint address="https://endpoint.domain.com/path/" behaviorConfiguration="BehaviorConfigurationName" ... />
        /// </client>
        /// ]]>
        /// </code>
        /// </remarks>
        public class ClientCertificateCredentialsFromFileElement : BehaviorExtensionElement
        {
            /// <summary>
            /// Creates a new <see cref="ClientCertificateCredentialsFromFile"/> from this configuration element.
            /// </summary>
            /// <returns>The newly configured <see cref="ClientCertificateCredentialsFromFile"/></returns>
            protected override object CreateBehavior()
            {
                return new ClientCertificateCredentialsFromFile(Source, Location);
            }
    
            /// <summary>
            /// Returns <code>typeof(<see cref="ClientCertificateCredentialsFromFile"/>);</code>
            /// </summary>
            public override Type BehaviorType
            {
                get
                {
                    return typeof(ClientCertificateCredentialsFromFile);
                }
            }
    
            /// <summary>
            /// An attribute used to configure the file location of the certificate to use for the client's credentials.
            /// </summary>
            [ConfigurationProperty("location", IsRequired = true)]
            public string Location
            {
                get
                {
                    return this["location"] as string;
                }
                set
                {
                    this["location"] = value;
                }
            }
    
            /// <summary>
            /// An attribute used to configure where the certificate should should be loaded from. 
            /// </summary>
            [ConfigurationProperty("source", IsRequired = true)]
            public CertificateSource Source
            {
                get
                {
                    return (CertificateSource)this["source"];
                }
                set
                {
                    this["source"] = value;
                }
            }
        }
    
        /// <summary>
        /// Used to declare the source of a certificate.
        /// </summary>
        public enum CertificateSource
        {
            FileOnDisk,
            EmbeddedResource
        }
    }
