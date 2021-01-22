    protected void Page_Load(object sender, EventArgs e)
    {
       //We create our new div
       System.Web.UI.HtmlControls.HtmlGenericControl newDiv = 
         new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
       newDiv.ID = "newSuperDIV"; //<---Give and ID to the div, very important!
       newDiv.Style.Value = "background-color:white; height:61%;"; //<---Add some style as example
       newDiv.Attributes.Add("class", "amazingCssClass"); //<---Apply a css class if wanted
       superDiv.Controls.Add(newDiv); //<---Add the new div to our already existing div
    }
