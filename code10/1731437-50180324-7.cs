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
            const string FILENAME = @"c:\temp\full database.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("IDs", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Products", typeof(string));
                dt.Columns.Add("Interaction ID", typeof(string));
                dt.Columns.Add("Interaction Name", typeof(string));
                dt.Columns.Add("Interaction Description", typeof(string));
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "drug")
                    {
                        reader.ReadToFollowing("drug");
                    }
                    if (!reader.EOF)
                    {
                        XElement drug = (XElement)XElement.ReadFrom(reader);
                        string type = (string)drug.Attribute("type");
                        string drugbank_id = string.Join(",", drug.Elements().Where(x => x.Name.LocalName == "drugbank-id").Select(x => (string)x));
                        string name = drug.Elements().Where(x => x.Name.LocalName == "name").Select(x => (string)x).FirstOrDefault();
                        List<XElement> products = drug.Descendants().Where(x => x.Name.LocalName == "product").ToList();
                        
                        string productsArray = products.Count == 0 ? "" :string.Join(",", products.Select(x => string.Format("[{0},{1}]", (string)x.Elements().Where(y => y.Name.LocalName == "name").FirstOrDefault(), (string)x.Elements().Where(y => y.Name.LocalName == "labeller").FirstOrDefault())));
                        foreach(XElement drug_interaction in drug.Descendants().Where(x => x.Name.LocalName == "drug-interaction"))
                        {   
                            string interactID = (string)drug_interaction.Elements().Where(x => x.Name.LocalName == "drugbank-id").Select(x => (string)x).FirstOrDefault();
                            string interactName = (string)drug_interaction.Elements().Where(x => x.Name.LocalName == "name").Select(x => (string)x).FirstOrDefault();
                            string description = (string)drug_interaction.Elements().Where(x => x.Name.LocalName == "description").Select(x => (string)x).FirstOrDefault();
                            DataRow newRow = dt.Rows.Add();
                            newRow["Type"] = type;
                            newRow["IDs"] = drugbank_id;
                            newRow["Name"] = name;
                            newRow["Products"] = productsArray;
                            newRow["Interaction ID"] = interactID;
                            newRow["Interaction Name"] = interactName;
                            newRow["Interaction Description"] = description;
                        }
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
