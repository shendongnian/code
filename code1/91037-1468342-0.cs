    public interface IControlXHost
    {
      // methods, properties that allow ControlX to access its dependencies
      int GetStuff();
    }
    public partial class ControlX : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var host = (Parent as IControlXHost) ?? (Page as IControlXHost);
            if (host == null) {
                throw new Exception("ControlX's parent must implement IControlXHost");
            }
            else {
                int number = host.GetStuff();
            }
        }
    }
