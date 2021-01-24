    using System.Net;
    using System;
     
    public class UpdateUser
    {
        static public void Main ()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true; //Install CUCM cert and remove this for production use
            WebClient client = new WebClient ();
            // Optionally specify an encoding for uploading and downloading strings.
            client.Encoding = System.Text.Encoding.UTF8;
            client.Headers.Add("Authorization","Basic QWRtaW5pc3RyYXRvcjpjaXNjb3BzZHQ=");
            client.Headers.Add("SOAPAction","CUCM:DB ver=11.5 updateUser");
            // Upload the data.
            string reply = client.UploadString ("https://ds-ucm115-1.cisco.com:8443/axl/","<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ns='http://www.cisco.com/AXL/API/8.5'><soapenv:Header/><soapenv:Body><ns:updateUser><userid>dstaudt3</userid><password>password</password><pin>123456</pin></ns:updateUser></soapenv:Body></soapenv:Envelope>");
            // Disply the server's response.
            Console.WriteLine (reply);
        }
    }
