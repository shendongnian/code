     static class WebControlsExtensions
     {
         public static void AddCssClass (this WebControl control, string cssClass)
         {
             control.CssClass += " " + cssClass;
         }
         public static void RemoveCssClass (this WebControl control, string cssClass)
         {
             control.CssClass = control.CssClass.replace(" " + cssClass, "");
         }
     }
