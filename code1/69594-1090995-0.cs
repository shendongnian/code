    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using CookComputing.XmlRpc;
    namespace Hello
    {
        /* proxy interface */
        [XmlRpcUrl("http://localhost:8888")]
        public interface IStateName : IXmlRpcProxy
        {
            [XmlRpcMethod("getTest")]
            string getTest();
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                /* implement section */
                IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
                string message = proxy.getTest();
                MessageBox.Show(message);
            }
        }
    }
