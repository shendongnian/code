    public class ControlEventSuspender : IDisposable
    {
        private const string eventsFieldName = "events";
        private const string headFieldName = "head";
        private static System.Reflection.FieldInfo eventsFieldInfo;
        private static System.Reflection.FieldInfo headFieldInfo;
        private System.Windows.Forms.Control target;
        private object eventHandlerList;
        private bool disposedValue;
        static ControlEventSuspender()
        {
            Type compType = typeof(System.ComponentModel.Component);
            eventsFieldInfo = compType.GetField(eventsFieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            headFieldInfo = typeof(System.ComponentModel.EventHandlerList).GetField(headFieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        }
        private static bool FieldInfosAquired()
        {
            if (eventsFieldInfo == null)
            {
                throw new Exception($"{typeof(ControlEventSuspender).Name} could not find the field '{ControlEventSuspender.eventsFieldName}' on type Component.");
            }
            if (headFieldInfo == null)
            {
                throw new Exception($"{typeof(ControlEventSuspender).Name} could not find the field '{ControlEventSuspender.headFieldName}' on type System.ComponentModel.EventHandlerList.");
            }
            return true;
        }
        private ControlEventSuspender(System.Windows.Forms.Control target) // Force using the the Suspend method to create an instance
        {
            this.target = target;
            this.eventHandlerList = eventsFieldInfo.GetValue(target); // backup event hander list
            eventsFieldInfo.SetValue(target, null); // clear event handler list
        }
        public static ControlEventSuspender Suspend(System.Windows.Forms.Control target)
        {
            ControlEventSuspender ret = null;
            if (FieldInfosAquired() && target != null)
            {
                ret = new ControlEventSuspender(target);
            }
            return ret;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (this.target != null)
                    {
                        RestoreEventList();
                    }
                }
            }
            this.disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        private void RestoreEventList()
        {
            object o = eventsFieldInfo.GetValue(target);
            if (o != null && headFieldInfo.GetValue(o) != null)
            {
                throw new Exception($"Events on {target.GetType().Name} (local name: {target.Name}) added while event handling suspended.");
            }
            else
            {
                eventsFieldInfo.SetValue(target, eventHandlerList);
                eventHandlerList = null;
                target = null;
            }
        }
    }
