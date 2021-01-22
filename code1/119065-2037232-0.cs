I suspect your problem is that the event isn't actually called Page_OnLoad in the class, it's OnLoad.  Here's how you want your class to look:
    public class MyPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            // Your code
            base.OnLoad(e);
        }
    }
