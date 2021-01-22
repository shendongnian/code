    public class PageBase : Page
    {
    
        public MyObject Foo 
        {
            get { return (MyObject)Session["myobject"]; }
            set { Session["myobject"] = value; }
        }
    }
