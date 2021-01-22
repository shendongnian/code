I know this is already marked as answered, but this is the code that inserts the ScriptManager if one is not found in the page:
public abstract class WebPartBase : WebPart
{
    protected override void OnInit(EventArgs e)
    {
        if (ScriptManager.GetCurrent(Page) == null)
        {
            ScriptManager scriptManager = new ScriptManager();
            scriptManager.ID = "ScriptManager1";
            scriptManager.EnablePartialRendering = true;
            Page.Form.Controls.AddAt(0, scriptManager);
        }
        base.OnInit(e);
    }
}
