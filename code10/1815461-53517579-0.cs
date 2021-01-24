    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace ProjectName
    {
        public partial class Login : Form
        {
            string[] servers = {"Server 1 Address", "Server 2 Address"};
            string connectionString = "";
            public Login()
            {
                
                InitializeComponent();
                this.Load += new EventHandler(Login_Load);
                
            }
            private void Login_Load(object sender, EventArgs e)
            {
                listBox1.DataSource = servers;
                listBox1.AllowDrop = true;
                listBox1.SelectedValueChanged +=new EventHandler(listBox1_SelectedValueChanged);
            }
            private void listBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                connectionString = string.Format(@"server={0};User id=User;Password=Password;Initial Catalog=DATABASE;Integrated Security=false", listBox1.Text);
            }
        }
    }
