    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            
            TextBox output = new TextBox 
            { 
                Multiline = true,
                Height = 350,
                Width = 200,
                Location = new Point (5, 15)
            };
            Button original = new Button
            { 
                Text = "Original",
                Location = new Point (210, 15)
            };
            original.Click += Log(output, "Click!");
            original.MouseEnter += Log(output, "MouseEnter");
            original.MouseLeave += Log(output, "MouseLeave");
            
            Button copyCat = new Button
            {
                Text = "CopyCat",
                Location = new Point (210, 50)
            };
            
            CopyEvents(original, copyCat, "Click", "MouseEnter", "MouseLeave");
            
            Form form = new Form 
            { 
                Width = 400, 
                Height = 420,
                Controls = { output, original, copyCat }
            };
            
            Application.Run(form);
        }
        
        private static void CopyEvents(object source, object target, params string[] events)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();
            MethodInfo invoker = typeof(MethodAndSource).GetMethod("Invoke");
            foreach (String eventName in events)
            {
                EventInfo sourceEvent = sourceType.GetEvent(eventName);
                if (sourceEvent == null)
                {
                    Console.WriteLine("Can't find {0}.{1}", sourceType.Name, eventName);
                    continue;
                }
                
                // Note: we currently assume that all events are compatible with
                // EventHandler. This method could do with more error checks...
                
                MethodInfo raiseMethod = sourceType.GetMethod("On"+sourceEvent.Name, 
                                                              BindingFlags.Instance | 
                                                              BindingFlags.Public | 
                                                              BindingFlags.NonPublic);
                if (raiseMethod == null)
                {
                    Console.WriteLine("Can't find {0}.On{1}", sourceType.Name, sourceEvent.Name);
                    continue;
                }
                EventInfo targetEvent = targetType.GetEvent(sourceEvent.Name);
                if (targetEvent == null)
                {
                    Console.WriteLine("Can't find {0}.{1}", targetType.Name, sourceEvent.Name);
                    continue;
                }
                MethodAndSource methodAndSource = new MethodAndSource(raiseMethod, source);
                Delegate handler = Delegate.CreateDelegate(sourceEvent.EventHandlerType,
                                                           methodAndSource,
                                                           invoker);
                                                           
                targetEvent.AddEventHandler(target, handler);
            }
        }
    
        private static EventHandler Log(TextBox output, string text)
        {
            return (sender, args) => output.Text += text + "\r\n";
        }
            
        private class MethodAndSource
        {
            private readonly MethodInfo method;
            private readonly object source;
            
            internal MethodAndSource(MethodInfo method, object source)
            {
                this.method = method;
                this.source = source;
            }
            
            public void Invoke(object sender, EventArgs args)
            {
                method.Invoke(source, new object[] { args });
            }
        }
    }
