           public class MetroToolWindowBase
           {
             public MetroToolWindowBase()
             {   
                Activated += new EventHandler(MakeActive); 
             }   
             private void MakeActive(object sender, EventArgs e)
             {
            App.ActivatedWindow= this;
             }
           }
