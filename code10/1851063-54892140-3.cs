    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public enum AlertType
        {
            success,
            info,
            warning,
            error
        }
    
        public partial class alert : Form
        {
            public alert()
            {
                InitializeComponent();
            }
    
            public alert(string _message, AlertType type, int top, int left)
            {
                InitializeComponent();
    
                this.StartPosition = FormStartPosition.Manual;
                this.Left = left;
                this.Top = top;
    
                this.Text = _message;
    
                switch (type)
                {
                    case AlertType.success:
                        this.BackColor = Color.SeaGreen;
                        break;
                    case AlertType.info:
                        this.BackColor = Color.Gray;
                        break;
                    case AlertType.warning:
                        this.BackColor = Color.FromArgb(255, 128, 0);
                        break;
                    case AlertType.error:
                        this.BackColor = Color.Crimson;
                        break;
                }
    
                this.Show();
            }
    
            private void alert_Load(object sender, EventArgs e)
            {
    
            }
        }
    }
