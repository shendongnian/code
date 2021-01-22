    public class Widget
    {
       private int count;
       public int Count
       {
          get { return this.count; }
          private set { this.count = value; }
       }
    }
    public static class WidgetManager
    {
        public static void CatastrophicErrorResetWidgetCount( Widget widget )
        {
           Type type = widget.GetType();
           PropertyInfo info = type.GetProperty("Count",BindingFlags.Instance|BindingFlags.NonPublic);
           info.SetValue(widget,0,null);
        }
    }
