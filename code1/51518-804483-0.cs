    [ToolboxData("<{0}:AlertControl runat=server></{0}:AlertControl>")]
    public class AlertControl : Control{
        protected override void OnInit(EventArgs e){
            base.OnInit(e);
            string script = "alert(\"Hello!\");";
            ScriptManager.RegisterStartupScript(this, GetType(), 
                          "ServerControlScript", script, true);
        }
    }
