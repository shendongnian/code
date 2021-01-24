    using System;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace StackOverflow06
    {
    	public partial class EasyXML : Form
    	{
    		public EasyXML()
    		{
    			InitializeComponent();
    		}
    		// Overriding this event just means that the app window 
    		// is now created so it's a good time to initialize 
    		// something like DataGridView
    		protected override void OnHandleCreated(EventArgs e)	
    		{
    			// Get the file, wherever it happens to be
    			string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\XMLFileSnippet.xml";
    			// Parse the file. Use Xml.Linq AS SUGGESTED BY: @jdweng
    			XElement doc = XElement.Load(fileName);  
  
    			// Xml.Linq finds "instance" elements only
    			foreach(XElement instance in doc.Descendants("instance"))
    			{
    				// Call constructor for each one found
    				Records.Add(new Record(instance)); //... and add it to a list
    			}
    
    			// Bind the DataGridView to show this list
    			dataGridView.DataSource = Records;
    
    			// Make the column formatting look nice
    			foreach (DataGridViewColumn col in dataGridView.Columns)
    			{
    				if (col.Name == "Labels") col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    				else col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    			}
    			base.OnHandleCreated(e);
    		}
    		// A class AS SUGGESTED BY: by @Jon Skeet
    		class Record
    		{
    			public Record(XElement instance)
    			{
    				ID = instance.Element("ID").Value;
    				Start = float.Parse(instance.Element("start").Value);
    				End = float.Parse(instance.Element("end").Value);
    				Code = instance.Element("code").Value;
    				var labelsTmp = from label in instance.Elements("label") select label.Element("text").Value;
    				Labels = string.Join(",", labelsTmp);
    			}
    			public string ID { get; set; }
    			public float Start { get; set; }
    			public float End { get; set; }
    			public string Code { get; set; }
    			public string Labels { get; set; }
    		}
    		// Make the DataGridView bound to this list of Records
    		BindingList<Record> Records = new BindingList<Record>();
    	}
    }
