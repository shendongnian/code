    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    public static class EventExtension
    {
        public static void RemoveEvents<T>(this T target, string eventName) where T:Control
        {
            if (ReferenceEquals(target, null)) throw new NullReferenceException("Argument \"target\" may not be null.");
            FieldInfo fieldInfo = typeof(Control).GetField(eventName, BindingFlags.Static | BindingFlags.NonPublic);
            if (ReferenceEquals(fieldInfo, null)) throw new ArgumentException(
                string.Concat("The control ", typeof(T).Name, " does not have a property with the name \"", eventName, "\""), nameof(eventName));
            object eventInstance = fieldInfo.GetValue(target);
            PropertyInfo propInfo = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)propInfo.GetValue(target, null);
            list.RemoveHandler(eventInstance, list[eventInstance]);
        }
    }
