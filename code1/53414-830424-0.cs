using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Messaging;
namespace ExportMSMQMessagesToFiles
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnExportTextFiles_Click(object sender, EventArgs e)
        {           
            //Setup MSMQ using path from user...
            MessageQueue q = new MessageQueue(txtMSMQ.Text);
            //Setup formatter... Whatever you want!?
            q.Formatter = new ActiveXMessageFormatter();
            // Loop over all messages and write them to a file... (in this case XML)
            MessageEnumerator msgEnum = q.GetMessageEnumerator2();
            int k = 0;
            while (msgEnum.MoveNext())
            {
                System.Messaging.Message msg = msgEnum.Current;                                
                string fileName = this.txtFileLocation.Text + "\\" + k + ".xml";                
                System.IO.File.WriteAllText(fileName, msg.Body.ToString());
                k++;
            }
            MessageBox.Show("All done!");
        }
    }
}
