    using System;
    using System.Windows.Forms;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string xml = @"<Activities>
        <Activity Sport=""Other"">
          <Id>2009-12-17T19:53:14Z</Id>
          <Lap StartTime=""2009-12-17T19:53:14Z"">
            <TotalTimeSeconds>820.5400000</TotalTimeSeconds>
            <DistanceMeters>1510.3433838</DistanceMeters>
            <MaximumSpeed>2.6089859</MaximumSpeed>
            <Calories>104</Calories>
            <AverageHeartRateBpm >
              <Value>128</Value>
            </AverageHeartRateBpm>
            <MaximumHeartRateBpm>
              <Value>139</Value>
            </MaximumHeartRateBpm>
            <Intensity>Active</Intensity>
            <TriggerMethod>Manual</TriggerMethod>
    </Lap>
    </Activity>
    </Activities>
    ";
                XDocument document = XDocument.Parse(xml);
    
                var query = from gtc in document.Descendants("Activity").Elements("Lap")
                            select new
                            {
                                Id = gtc.Parent.Element("Id").Value,
                                StartTime = gtc.Attribute("StartTime").Value,
                                TotalSeconds = gtc.Element("TotalTimeSeconds").Value,
                                DistanceMeters = gtc.Element("DistanceMeters").Value,
                                MaximumSpeed = gtc.Element("MaximumSpeed").Value,
                                Calories = gtc.Element("Calories").Value,
                                Intensity = gtc.Element("Intensity").Value,
                                TriggerMethod = gtc.Element("TriggerMethod").Value,
                                AverageHeartRateBpm = gtc.Element("AverageHeartRateBpm").Element("Value").Value,
                                MaximumHeartRateBpm = gtc.Element("MaximumHeartRateBpm").Element("Value").Value
                            };
    
                dataGridView1.DataSource = query.ToList();
    
            }
        }
    }
