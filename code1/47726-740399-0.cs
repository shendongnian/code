     public class WidgetDictionary : Dictionary<string,Widget>
     {
         ... provide suitable constructors ...
         public void Add( Widget widget )
         {
             if (widget != null && !this.ContainsKey( widget.FilePath ))
             {
                 this.Add( widget.FilePath, widget );
             }
         }
     }
     public class Widget
     {
          public string FilePath { get; set; }
          private List<Widget> widgets = new List<Widget>();
          public IEnumerable<Widget> Widgets
          {
              get { return widgets; }
          }
          ...code to add/remove widgets from list...
     }
