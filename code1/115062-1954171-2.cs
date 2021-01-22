    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Office = Microsoft.Office.Core;
    using System.Windows.Forms;
    
    namespace OutlookAddInMishko
    {
        public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
    
                Inspectors = this.Application.Inspectors;
                Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
    
            #region VSTO generated code
    
    
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
           
            #endregion
    
    
              private Office.CommandBarButton buttonOne;
    
            private Outlook.Inspectors Inspectors;
            public static Microsoft.Office.Interop.Outlook.Inspector InsMail;
    
            void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
            {
                Outlook.MailItem tmpMailItem = (Outlook.MailItem)Inspector.CurrentItem;
    
                if (Inspector.CurrentItem is Outlook.MailItem)
                {
                    tmpMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                    bool exists = false;
                    foreach (Office.CommandBar cmd in Inspector.CommandBars)
                    {
                        if (cmd.Name == "EAD")
                        {
                            //exists = true;
                            cmd.Delete();
                        }
                    }
    
                    Office.CommandBar newMenuBar = Inspector.CommandBars.Add("EAD", Office.MsoBarPosition.msoBarTop, false, true);
                    buttonOne = (Office.CommandBarButton)newMenuBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);
    
                    if (!exists)
                    {
                        buttonOne.Caption = "Scan this mail";
                        buttonOne.Style = Office.MsoButtonStyle.msoButtonCaption;
                        buttonOne.FaceId = 1983;
    
                        //Register send event handler
                        buttonOne.Click += new Office._CommandBarButtonEvents_ClickEventHandler(buttonOne_Click);
                        newMenuBar.Visible = true;
                    }
                }
    
    
            }
    
    
            private void buttonOne_Click(Office.CommandBarButton ctrl, ref bool cancel)
            {
                ProcessMessages();
            }
    
            private Form1 form1 = null;
    
            private void ProcessMessages()
            {
                if (form1 == null)
                {
                    form1 = new Form1(this.Application);
                }
                form1.ShowDialog();
            }
    
    
        }
    }
    
    
    namespace OutlookAddInMishko
    {
        public partial class Form1 : Form
        {
            protected Outlook.Application App;
            public Form1()
            {
                InitializeComponent();
            }
            public Form1(Outlook.Application _app)
            {
                App = _app;
                InitializeComponent();
            }
    
            private void Form1_Shown(object sender, EventArgs e)
            {
                label1.Text = "Total number of mails in inbox: " + App.ActiveExplorer().CurrentFolder.Items.Count.ToString();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Outlook.MailItem item = (Outlook.MailItem)App.ActiveInspector().CurrentItem;
                textBox1.Text += "From:    " + item.SenderName + "\r\n\n";
                textBox1.Text += "Subject: " + item.Subject + "\r\n\n";
                textBox1.Text += "Body: \r\n\n" + item.Body + "\r\n";
                textBox1.Text += "Mail contains:    " + item.Attachments.Count + " attachment(s).\r\n\n";
            }
        }
    }
