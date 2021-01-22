        public static void RemoveItemEvents<T>(this T target, string eventName) 
            where T : ToolStripItem
        {            
            RemoveObjectEvents<T>(target, eventName);
        }
        public static void RemoveControlEvents<T>(this T target, string eventName)
            where T : Control
        {
            RemoveObjectEvents<T>(target, eventName);
        }
        private static void RemoveObjectEvents<T>(T target, string Event) where T : class
        {
            var typeOfT = typeof(T);
            var fieldInfo = typeOfT.BaseType.GetField(
                Event, BindingFlags.Static | BindingFlags.NonPublic);
            var provertyValue = fieldInfo.GetValue(target);
            var propertyInfo = typeOfT.GetProperty(
                "Events", BindingFlags.NonPublic | BindingFlags.Instance);
            var eventHandlerList = (EventHandlerList)propertyInfo.GetValue(target, null);
            eventHandlerList.RemoveHandler(provertyValue, eventHandlerList[provertyValue]);
        }
