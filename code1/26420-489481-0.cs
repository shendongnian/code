    using System;
    using System.IO;
    using System.Web.Services;
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public bool RecieveBytes(byte[] data)
        {
            try
            {
                File.WriteAllBytes("~/uploads/uploadedFile.dat", data);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
