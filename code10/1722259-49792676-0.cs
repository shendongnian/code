    public class Program {
        public static void Main() {
            var target = new EventAssign
            {
                Prop = "test"
            };
            target.Changed += (sender, args) =>
            {
                Console.WriteLine("Invoked!");
            };
            var copy = Copy(target);
            target.InvokeChanged();
            // handler was copied too, so invoking event on copy
            // will also run handler above
            copy.InvokeChanged();
        }
        static EventAssign Copy(EventAssign target) {
            var copy = new EventAssign();
            copy.Prop = target.Prop;
            // get all events via reflection
            var publicEvents = typeof(EventAssign).GetEvents(BindingFlags.Instance | BindingFlags.Public);
            foreach (var ev in publicEvents) {
                // each "regular" event (without custom add\remove) should have
                // a backing field with the same name
                var evField = typeof(EventAssign).GetField(ev.Name, BindingFlags.Instance | BindingFlags.NonPublic);
                if (evField == null || evField.FieldType != ev.EventHandlerType)
                    continue;
                // copy this field value
                evField.SetValue(copy, evField.GetValue(target));
            }
            return copy;
        }
    }
    class EventAssign {
        public string Prop { get; set; }
        public event EventHandler Changed;
        public void InvokeChanged() {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
