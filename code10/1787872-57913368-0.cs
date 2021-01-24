    public class MyCertificateValidator : X509CertificateValidator
    {
        private readonly string _allowedCertificateEncodedValue;
        public MyCertificateValidator(string allowedCertificateEncodedValue)
        {
            _allowedCertificateEncodedValue = allowedCertificateEncodedValue ?? throw new ArgumentNullException("allowedCertificateEncodedValue");
        }
        public override void Validate(X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }
            var allowedCertificateEncodedValue = Convert.ToBase64String(certificate.RawData);
            if (_allowedCertificateEncodedValue != allowedCertificateEncodedValue)
            {
                throw new SecurityTokenValidationException("Certificate does not match the provided encoded value.");
            }
        }
    }
