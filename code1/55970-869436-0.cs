    public class MyUserControlViewModel
    {
        public Decimal MyValue { get; private set; }
        public MyUserControlViewModel(Decimal dec)
        {
            MyValue = dec;
        }
    }
    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MyUserControlViewModel>" %>
    <%= Math.Round(Model.MyValue) %>
