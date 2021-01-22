    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Updater textboxUpdater = new Updater();
                textboxUpdater.Updated += s => {textBox1.Text = s;};
            }
        }
 
    public class Updater
        {
            public delegate void UpdateEventHandler(string eventName);
            public event UpdateEventHandler Updated = delegate { };
    
            private bool needUpdating;
            public void Process()
            {
                while (true)
                {
                    //Processing
                    if (needUpdating)
                    {
                        Updated("something");
                    }
                }
            }
    
        }
