    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    namespace ConsoleApplication {
        class Program {
            static void Main() {
                Form form;
            
                form = createForm();
                form.ShowDialog();
                form = createForm();
                invertShownOrder(form);
                form.ShowDialog();
            }
            static Form createForm() {
                var form = new Form();
                form.Shown += (sender, args) => { Console.WriteLine("form_Shown1"); };
                form.Shown += (sender, args) => { Console.WriteLine("form_Shown2"); };
                return form;
            }
        
            static void invertShownOrder(Form form) {
                var events = typeof(Form)
                    .GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(form, null) as EventHandlerList;
                var shownEventKey = typeof(Form)
                    .GetField("EVENT_SHOWN", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(form);
                var shownEventHandler = events[shownEventKey] as EventHandler;
                if (shownEventHandler != null) {
                    var invocationList = shownEventHandler
                        .GetInvocationList()
                        .OfType<EventHandler>()
                        .ToList();
                    foreach (var handler in invocationList) {
                        events.RemoveHandler(shownEventKey, handler);
                    }
                    for (int i = invocationList.Count - 1; i >= 0; i--) {
                        events.AddHandler(shownEventKey, invocationList[i]);
                    }
                }
            }
        }
    }
