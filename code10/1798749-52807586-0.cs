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
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                //data will be from the database a string
                //I'm reading fron a file for testing
                string xml = File.ReadAllText(FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("MusicID", typeof(int));
                dt.Columns.Add("AlbumDesc", typeof(string));
                dt.Columns.Add("AlbumDate", typeof(DateTime));
                dt.Columns.Add("AlbumPrice", typeof(decimal));
                XDocument doc = XDocument.Parse(xml);
                foreach(XElement album in doc.Descendants("AlbumDetail"))
                {
                    dt.Rows.Add(new object[] {
                        (int)album.Element("MusicID"),
                        (string)album.Element("AlbumDesc"),
                        (DateTime)album.Element("AlbumDate"),
                        (decimal)album.Element("AlbumPrice")
                    });
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
