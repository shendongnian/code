    //includes on top
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    //Do webrequest to get info on secure site
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://securesite.com");
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    response.Close();
    
    //retrieve the ssl cert and assign it to an X509Certificate object
    X509Certificate cert = request.ServicePoint.Certificate;
    
    //convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
    X509Certificate2 cert2 = new X509Certificate2(cert);
    
    //display the cert dialog box
    X509Certificate2UI.DisplayCertificate(cert2);
