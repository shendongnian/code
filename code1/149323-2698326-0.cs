      /// <summary>
      /// Determine if a control has the event visible subscribed to
      /// </summary>
      /// <param name="controlObject">The control to look for the VisibleChanged event</param>
      /// <returns>True if the control is subscribed to a VisibleChanged event, False otherwise</returns>
      private bool IsSubscribed(Control controlObject)
      {
         FieldInfo event_visible_field_info = typeof(Control).GetField("EventVisible",
            BindingFlags.Static | BindingFlags.NonPublic);
         object object_value = event_visible_field_info.GetValue(controlObject);
         PropertyInfo events_property_info = controlObject.GetType().GetProperty("Events",
            BindingFlags.NonPublic | BindingFlags.Instance);
         EventHandlerList event_list = (EventHandlerList)events_property_info.GetValue(controlObject, null);
         return (event_list[object_value] != null);
      }
