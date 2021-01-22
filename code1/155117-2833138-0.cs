public class MyLabel : Label
{
	protected override void OnInit(EventArgs e)
        {
            this.InitLinkButton();
            base.OnInit(e);       
            
        }
	public void InitLinkButton()
	{
	   System.Web.UI.HtmlControls.HtmlGenericControl div=new System.Web.UI.HtmlControls.HtmlGenericControl("div");
	   HyperLink lnk = new HyperLink();
           lnk.NavigateUrl = "http://www.abc.com";
           lnk.Text = "Click here to go to abc.com";
           div.Controls.Add(lnk);  
           //same way you add more link to div
	   //finally adding this to base control.
	   base.Controls.Add(div);
	}
}
