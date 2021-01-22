     public class Nodes
     {
         private Form TheForm { get; set; }
         public Nodes( Form form )
         {
              this.TheForm = form;
         }
         public void UpdateSomething( EventArgs args )
         {
             ...
             this.Form.ChangeText( newValue );
             ...
         }
    }
