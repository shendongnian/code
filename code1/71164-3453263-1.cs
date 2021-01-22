      public class TableHandler : DependencyObject
      {
         static TableHandler()
         {
            TableHandler.Tables = new List<Table>();
         }
         // holds list of Tables added by setting HandleTable to true
         public static List<Table> Tables { get; private set; }
         // fires UpdateTable attached event for all Tables 
         public static void RaiseUpdateTableEvent()
         {
            foreach (Table table in TableHandler.Tables)
            {
               RoutedEventArgs e = new RoutedEventArgs(TableHandler.UpdateTableEvent,
                                          table);
               table.RaiseEvent(e);
            }      
         }
      
         #region UpdateTable Attached Routed Event
         public static readonly RoutedEvent UpdateTableEvent =
            EventManager.RegisterRoutedEvent("UpdateTable",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(TableHandler));
         public event RoutedEventHandler UpdateTable
         {
            add 
            {
               TableHandler.DoAddUpdateTableHandler(this, value);
            }
            remove 
            {
               TableHandler.DoRemoveUpdateTableHandler(this, value);
            }
         }
         public static void DoAddUpdateTableHandler(DependencyObject obj,
                                RoutedEventHandler handler)
         {
            UIElement el = obj as UIElement;
            if (el != null)
            {
               el.AddHandler(TableHandler.UpdateTableEvent, handler);
            }
         }
         public static void DoRemoveUpdateTableHandler(DependencyObject obj, 
                                RoutedEventHandler handler)
         {
            UIElement el = obj as UIElement;
            if (el != null)
            {
               el.RemoveHandler(TableHandler.UpdateTableEvent, handler);
            }
         }
         #endregion
         #region HandleTable Attached Property (with callback)
         public static readonly DependencyProperty HandleTableProperty =
            DependencyProperty.RegisterAttached(
               "HandleTable",
               typeof(bool),
               typeof(TableHandler),
               new FrameworkPropertyMetadata
                     {
                        PropertyChangedCallback = TableHandler.OnHandleTableChanged,
                        DefaultValue = false
                     });
         public static void SetHandleTable(DependencyObject element, bool value)
         {
            element.SetValue(HandleTableProperty, value);
         }
         public static bool GetHandleTable(DependencyObject element)
         {
            return (bool)element.GetValue(HandleTableProperty);
         }
         static void OnHandleTableChanged
             (DependencyObject obj, DependencyPropertyChangedEventArgs args)
         {
            Table t = obj as Table;
            if (t != null)
            {
               TableHandler.Tables.Add(t);
            }
         }
         #endregion                 
      }
