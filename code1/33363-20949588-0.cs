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
    using System.Xml.XPath;
    using System.Xml.Serialization;
    
    namespace CreateSampleXML
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();            
                XNamespace xm = "http://somewhere.com";
                XElement rt= new XElement("Root", new XAttribute(XNamespace.Xmlns + "brk", "http://somewhere.com"));
                XElement cNode = new XElement("child1");
                cNode.Add(new XElement(xm + "node1", 123456));
                cNode.Add(new XElement(xm + "node2", 500000000));
                rt.Add(cNode);
                XDocument doc2 = new XDocument(rt);
                doc2.Save(@"C:\sample3.xml");
            }
        }       
    }
