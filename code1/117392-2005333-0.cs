    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Style style = new Style();
        style.ForeColor = Color.Green;
        this.Page.Header.StyleSheet.CreateStyleRule(style, this, "." + HyperLink1.ClientID + ":hover");
    
        HyperLink1.CssClass = this.HyperLink1.ClientID;
    }
