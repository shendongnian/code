    public class CustomTabRenderer: TabbedRenderer 
       {
            private Activity _act;
    
            protected override void OnModelChanged(VisualElement oldModel, VisualElement newModel)
            {
                base.OnModelChanged(oldModel, newModel);
    
                _act = this.Context as Activity;
            }
    
            // You can do the below function anywhere.
            public override void OnWindowFocusChanged(bool hasWindowFocus)
            {   
                
                ActionBar actionBar = _act.ActionBar;
    
                if (actionBar.TabCount > 0)
                {
                    Android.App.ActionBar.Tab tabOne = actionBar.GetTabAt(0);
    
                   tabOne.SetIcon(Resource.Drawable.shell);
                }
                base.OnWindowFocusChanged(hasWindowFocus);
            }
        }
