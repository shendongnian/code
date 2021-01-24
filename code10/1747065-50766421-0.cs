    public class SuspendedEvents
    {
        private Dictionary<FieldInfo, Delegate> handlers = new Dictionary<System.Reflection.FieldInfo, System.Delegate>();
        private object source;
    
        public SuspendedEvents(object obj)
        {
            source = obj;
            var fields = obj.GetType().GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var fieldInfo in fields.Where(fi => fi.FieldType.IsSubclassOf(typeof(Delegate))))
            {
                var d = (Delegate)fieldInfo.GetValue(obj);
                handlers.Add(fieldInfo, (Delegate)d.Clone());
                fieldInfo.SetValue(obj, null);
            }
        }
    
        public void Restore()
        {
            foreach (var storedHandler in handlers)
            {
                storedHandler.Key.SetValue(source, storedHandler.Value);
            }
        }
    }
