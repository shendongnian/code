    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    //ALTER DATABASE HOB SET ENABLE BROKER
    namespace DemoSQL
    {
        public partial class Form1 : Form
        {
            public string m_connect = @"Data Source=DESKTOP-3B561M1;Initial Catalog=Users;Integrated Security=True";
            SqlConnection con = null;
            public delegate void NewHome();
            public event NewHome OnNewHome;
            public Form1()
            {
                InitializeComponent();
                try
                {
                    SqlClientPermission ss = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                    ss.Demand();
                }
                catch (Exception)
                {
    
                    throw;
                }
                SqlDependency.Stop(m_connect);
                SqlDependency.Start(m_connect);
                con = new SqlConnection(m_connect);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                OnNewHome+=new NewHome(Form1_OnNewHome);//tab
                //load data vao datagrid
                LoadData();
            }
    
            public void Form1_OnNewHome()
            {
                ISynchronizeInvoke i = (ISynchronizeInvoke)this;
                if (i.InvokeRequired)//tab
                {
                    NewHome dd = new NewHome(Form1_OnNewHome);
                    i.BeginInvoke(dd, null);
                    return;
                }
                LoadData();
    
            }
    
            //Ham load data
            void LoadData()
            {
                DataTable dt = new DataTable();
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }      
    
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.Uss", con);
                cmd.Notification = null;
    
                SqlDependency de = new SqlDependency(cmd);
                de.OnChange += new OnChangeEventHandler(de_OnChange);
    
                dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                dataGridView1.DataSource = dt;
            }
            public void de_OnChange(object sender, SqlNotificationEventArgs e)
            {
                SqlDependency de = sender as SqlDependency;
                de.OnChange -= de_OnChange;
                if (OnNewHome!=null)
                {
                    OnNewHome();
                }
            }
        }
    }
