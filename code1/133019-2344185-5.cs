    using System.Windows;
    using System.Windows.Data;
    using System.Xml;
    namespace Test
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                XmlDocument d = new XmlDocument();
                string xml = @"<Config><Tabs><Tab Name='foo'/><Tab Name='bar'/></Tabs></Config>";
                d.LoadXml(xml);
                ((XmlDataProvider) Resources["Data"]).Document = d;
            }
        }
    }
