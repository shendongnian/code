    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.IO;
    namespace TestWS
    {
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        private string GetFileName ()
        {
            if (File.Exists("index.dat"))
            {
                using (StreamReader lReader = new StreamReader("index.dat"))
                {
                    return lReader.ReadLine();
                }
            }
            else
            {
                using (StreamWriter lWriter = new StreamWriter("index.dat"))
                {
                    string lFileName = Path.GetRandomFileName();
                    lWriter.Write(lFileName);
                    return lFileName;
                }
            }
        }
        
        [WebMethod]
        public string WriteChunk(byte[] aData)
        {
            Directory.SetCurrentDirectory(Server.MapPath("Data"));
            DateTime lStart = DateTime.Now;
            using (FileStream lStream = new FileStream(GetFileName(), FileMode.Append))
            {
                BinaryWriter lWriter = new BinaryWriter(lStream);
                lWriter.Write(aData);
            }
            DateTime lEnd = DateTime.Now;
            return lEnd.Subtract(lStart).TotalMilliseconds.ToString();
        }
    }
