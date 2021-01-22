    using System;
    using System.Windows.Forms;
    using Common.Core.Extensions.DateTime;
    namespace AddBusinessDaysTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                label1.Text = DateTime.Now.AddBusinessDays(5).ToString();
                label2.Text = DateTime.Now.AddBusinessDays(-36).ToString();
            }
        }
    }
