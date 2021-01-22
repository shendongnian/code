      public class ProxiedScriptManager : ScriptManagerProxy
      {
        protected override void OnInit(EventArgs e)
        {
          //double check for script-manager, if one doesn't exist, 
          //then create one and add it to the page
          if (ScriptManager.GetCurrent(this.Page) == null)
          {
            ScriptManager sManager = new ScriptManager();
            sManager.ID = "sManager_" + DateTime.Now.Ticks;
            Controls.AddAt(0, sManager);
          }
    
          base.OnInit(e);
        }
      }
