    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace ConsoleApp
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Form form = new Form { Size = new Size(400, 200) };
                Button button = new Button { Text = "Click me" };
                form.Controls.Add(button);
                EventSubscriber.SubscribeAll(button);
                Application.Run(form);
            }
        }
    
        class EventSubscriber
        {
            private static readonly MethodInfo HandleMethod = 
                typeof(EventSubscriber)
                    .GetMethod("HandleEvent", 
                               BindingFlags.Instance | 
                               BindingFlags.NonPublic);
    
            private readonly EventInfo evt;
    
            private EventSubscriber(EventInfo evt)
            {
                this.evt = evt;
            }
    
            private void HandleEvent(object sender, EventArgs args)
            {
                Console.WriteLine("Event {0} fired", evt.Name);
            }
    
            private void Subscribe(object target)
            {
                Delegate handler = Delegate.CreateDelegate(
                    evt.EventHandlerType, this, HandleMethod);
                evt.AddEventHandler(target, handler);
            }
    
            public static void SubscribeAll(object target)
            {
                foreach (EventInfo evt in target.GetType().GetEvents())
                {
                    EventSubscriber subscriber = new EventSubscriber(evt);
                    subscriber.Subscribe(target);
                }
            }
        }
    }
