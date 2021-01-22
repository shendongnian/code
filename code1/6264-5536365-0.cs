    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    public static class EventExtension
    {
        public static void RemoveEvents<T>(this Control target,string Event)
        {
                FieldInfo f1 = typeof(Control).GetField(Event,BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(target.CastTo<T>());
                PropertyInfo pi =target.CastTo<T>().GetType().GetProperty("Events",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(target.CastTo<T>(), null);
                list.RemoveHandler(obj, list[obj]);
          
    
        }
    }
