    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          button1.Click += new EventHandler(button1_Click);
          // Get secret click event key
          FieldInfo eventClick = typeof(Control).GetField("EventClick", BindingFlags.NonPublic | BindingFlags.Static);
          object secret = eventClick.GetValue(null);
          // Retrieve the click event
          PropertyInfo eventsProp = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
          EventHandlerList events = (EventHandlerList)eventsProp.GetValue(button1, null);
          Delegate click = events[secret];
          // Remove it from button1, add it to button2
          events.RemoveHandler(secret, click);
          events = (EventHandlerList)eventsProp.GetValue(button2, null);
          events.AddHandler(secret, click);
        }
    
        void button1_Click(object sender, EventArgs e) {
          MessageBox.Show("Yada");
        }
      }
    }
