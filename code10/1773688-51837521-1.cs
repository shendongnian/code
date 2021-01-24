    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public class Client
            {
                public bool IsSignedIn { get; set; }
            }
    
            Client client = new Client()
            {
                IsSignedIn = false
            };
    
            public Form1()
            {
                InitializeComponent();
            }
            public void CheckSignedInState()
            {
                // some other code
    
                DrawClientStateIcon(client.IsSignedIn);
            }
    
            private void DrawClientStateIcon(bool isSignedIn)
            {
                Point rectangleLocation = picBoxClientState.Location;
                Size rectangleSize = picBoxClientState.Size;
                Rectangle rectangle = new Rectangle(rectangleLocation, new Size(rectangleSize.Width / 2, rectangleSize.Height / 2));
    
                Color iconColor = isSignedIn ? Color.Green : Color.Red;
    
                using (SolidBrush iconBrush = new SolidBrush(iconColor))
                {
                    using (Graphics graphics = picBoxClientState.CreateGraphics())
                    {
                        graphics.FillEllipse(iconBrush, rectangle);
                    }
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                client.IsSignedIn = !client.IsSignedIn;
                CheckSignedInState();
            }
        }
    }
