    // We'll use this class to communicate
    public class Dog
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    // This is your page, in my case Default.aspx
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static string ProcessData(Dog myDog)
        {
            return "Your " + myDog.Color + " dog's name is " + myDog.Name + "!";
        }
    }
