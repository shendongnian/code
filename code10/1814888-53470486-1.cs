    //the wrapper
    public class PropertyPages : IPropertyPages
    {
         //your wrapped form...
         private YourForm _propertyForm = new YourForm(); 
         //a public show, but the form itself remain inaccessible.
         public void Show()
         {
             _propertyForm.Show();
         }
    }
