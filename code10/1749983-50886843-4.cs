    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace WpfApp2
    {
        public partial class MainWindow : Window
        {
            public class YourClass
            {
                public string Name { get; set; }
                public string Age { get; set; }
                public string Mail { get; set; }
            }
    
            public ObservableCollection<YourClass> AllMyData { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                AllMyData = new ObservableCollection<YourClass>();
                for (var i = 0; i < 3; i++)
                {
                    AllMyData.Add(new YourClass { Name = i.ToString() });
                }
                this.DataContext = this;
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(List<YourClass>));
                var subReq = AllMyData.ToList();
                var xml = "";
    
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, subReq);
                        xml = sww.ToString(); // Your XML
                        Debugger.Break();
                    }
                }
            }
        }
    }
