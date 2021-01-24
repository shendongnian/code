            //**********************
            object objNew = obj.GetType().GetConstructor(new Type[] { }).Invoke(new object[] { });
            PropertyInfo propEvents = obj.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList eventHandlerList_obj = (EventHandlerList)propEvents.GetValue(obj, null);
            EventHandlerList eventHandlerList_objNew = (EventHandlerList)propEvents.GetValue(objNew, null);
            eventHandlerList_objNew.AddHandlers(eventHandlerList_obj);
            eventHandlerList_obj.Dispose();
            return eventHandlerList_objNew;
        }
