    class MyUserControl : UserControl
    {
       delegate object MyDelegate(object arg1, object arg2, object argN);
       public MyDelegate MyPageMethod;
       
       public void InvokeDelegate(object arg1, object arg2, object argN)
       {
         if(MyDelegate != null)
            MyDelegate(arg1, arg2, argN); //Or you can leave it without the check 
                                          //so it can throw an exception at you.
       }
    }
    class MyPageUsingControl : Page
    {
       protected void Page_Load(object sender, EventArgs e)
       {
         if(!Page.IsPostBack)
            MyUserContorlInstance.MyPageMethod = PageMethod;
       }
       public object PageMethod(object arg1, object arg2, object argN)
       {
         //The actions I want
       }
    }
    
