    //Parent Page aspx.cs part
     public partial class getproductdetails : System.Web.UI.Page
     {
      protected void Page_Load(object sender, EventArgs e)
      {
       ucPrompt.checkIfExist += new uc_prompt.customHandler(MyParentMethod);
      }
      bool MyParentMethod(object sender)
      {
       //Do Work
      }
    }
    //User control parts
    public partial class uc_prompt : System.Web.UI.UserControl
    {
     protected void Page_Load(object sender, EventArgs e)
     {
     }
     public delegate bool customHandler(object sender);
     public event customHandler checkIfExist;
     protected void btnYes_Click(object sender, EventArgs e)
     {
      checkIfExist(sender);
     }
    }
