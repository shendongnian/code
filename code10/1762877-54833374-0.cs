c#
using Org.BouncyCastle.Asn1.X509;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
...
X509Certificate2 certificate = ...
var name = new X509Name(certificate.Subject);
var organization = name
  .GetValueList(X509Name.O)
  .OfType<string>()
  .FirstOrDefault();
