    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace TestSqlDependancies
    {
    public partial class SqlDependencyTester : Form
        {
            SqlDependency sqlDepenency = null;
            SqlCommand command;
            SqlNotificationEventArgs msg;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
            }
            public delegate void InvokeDelegate();
            void sqlDepenency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                msg = e;
                this.BeginInvoke(new InvokeDelegate(Notify));
            }
            
            private void Notify()
            {
                listBox1.Items.Add(DateTime.Now.ToString("HH:mm:ss:fff") + " - Notfication received. SqlDependency " + (sqlDepenency.HasChanges ? " has changes." : " reports no change. ") + msg.Type.ToString() + "-" + msg.Info.ToString());
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                SetDependency();
            }
    
            private void SetDependency()
            {
                try
                {
                    using (TicketDataContext dc = new TicketDataContext())
                    {
                        SqlDependency.Start(dc.Connection.ConnectionString);
                        command = new SqlCommand(textBox1.Text, (SqlConnection)dc.Connection);
                        sqlDepenency = new SqlDependency(command);
                        sqlDepenency.OnChange += new OnChangeEventHandler(sqlDepenency_OnChange);
                        command.Connection.Open();
                        command.ExecuteReader();
                    }
                }
                catch (Exception e)
                {
                    listBox1.Items.Add(DateTime.Now.ToString("HH:mm:ss:fff") + e.Message);
                }
            }
        }
    }
