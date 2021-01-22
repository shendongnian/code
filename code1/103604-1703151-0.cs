     private void ctxlistAction_Click(object sender, EventArgs e)
     {
          UIView view = sender as UIView;
    
          if (view != null)
          {
    
             // I can unify the Viewer and ListView and implement some common interface,
             // so I'm pretty sure I can handle this part
             foreach (Process p in view.SelectedProcesses())
             {
                 p.Action(); // What is the best way to handle this?
             }
             BeginRefresh(false, false);
          }
      }
