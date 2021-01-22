    public partial class Form1 : Form
    {
            public Form1()
            {
                InitializeComponent();
    
                button1.Click += button1_Click;
                button1.Click += button1_Click2;
                button2.Click += button2_Click;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Hello");
            }
    
            private void button1_Click2(object sender, EventArgs e)
            {
                MessageBox.Show("World");
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                RemoveClickEvent(button1);
            }
    
            void RemoveClickEvent(Button b)
            {
                FieldInfo f1 = typeof(Control).GetField("EventClick", 
                    BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(b);
                PropertyInfo pi = b.GetType().GetProperty("Events",  
                    BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
                list.RemoveHandler(obj, list[obj]);
            }
        }
    }
