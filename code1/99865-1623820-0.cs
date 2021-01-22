    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class DataBindingTest : Form
    {
        public event EventHandler FirstNameChanged;
        
        string m_sFirstName = "Brad";
        public string FirstName
        {
            get { return m_sFirstName; }
            set 
            { 
                m_sFirstName = value;
                EventHandler handler = FirstNameChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    
        public DataBindingTest()
        {
            Size = new Size(100, 100);
            TextBox textBox = new TextBox();
            textBox.DataBindings.Add("Text", this, "FirstName");
            
            Button button = new Button
            { 
                Text = "Rename",
                Location = new Point(10, 30)
            };
            button.Click += delegate { FirstName = "John"; };
            Controls.Add(textBox);
            Controls.Add(button);
        }
    
        static void Main()
        {
            Application.Run(new DataBindingTest());
        }
    }
