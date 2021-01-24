    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            XDocument doc = null;
            XElement tickets = null;
            public Form1()
            {
                InitializeComponent();
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                string ident = "<?xml version=\"1.0\" encoding=\"utf-8\"?><tickets></tickets>";
                doc = XDocument.Parse(ident);
                tickets = doc.Root;
                
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                doc.Save(FILENAME);
            }
            private void addTicket_Click(object sender, EventArgs e)
            {
                XElement newTicket = new XElement("ticket",
                    new XElement("ID", this.ID),
                    new XElement("Name", this.Name),
                    new XElement("Type", this.Type),
                    new XElement("Device_Name", this.Device_Name),
                    new XElement("Serial_Number", this.Number),
                    new XElement("Repair_Data", this.Repair),
                    new XElement("Fix", this.Fix),
                    new XElement("Additional", this.Additional)
                    );
                tickets.Add(newTicket);
            }
        }
    }
