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
    namespace WindowsFormsApplication19
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
            }
            private void buttonReadXml_Click(object sender, EventArgs e)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                List<string> output = new List<string>();
                output.Add(root.Name.LocalName);
                RecursiveParse(root, output);
            }
            void RecursiveParse(XElement element, List<string> output)
            {
                if (element.HasElements)
                {
                    foreach (XElement newElement in element.Elements())
                    {
                        List<string> newOutput = new List<string>(); ;
                        newOutput.AddRange(output);
                        newOutput.Add(newElement.Name.LocalName);
                        RecursiveParse(newElement, newOutput);
                    }
                }
                else
                {
                    List<string> newOutput = new List<string>();
                    newOutput.AddRange(output);
                    newOutput.Add((string)element);
                    textBox1.Text += string.Join(",", newOutput) + "\r\n";
                }
            }
        }
    }
