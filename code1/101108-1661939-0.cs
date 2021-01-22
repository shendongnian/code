    ///Server side
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public byte[] GetFile(string fullName)
        {
            return File.ReadAllBytes(fullName);
        }
    }
    ///Client Side
    private void button1_Click(object sender, EventArgs e)
    {
        Service1 client = new Service1();
        pictureBox1.Image = Image.FromStream(
            new MemoryStream(
                client.GetFile("c:\\apple.jpg")));
    }
