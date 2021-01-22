    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Xml;
    
    namespace LoadTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                SelectedColors = new Dictionary<string, ColorInfo>();
                SelectedColors.Add("color0", AvailableColors.First());
                SelectedColors.Add("color1", AvailableColors.Last());
    
                XmlReader xaml = XmlReader.Create("newcontrol.xml");
                newControl.Content = XamlReader.Load(xaml);
                newControl.DataContext = SelectedColors;
    
                DataContext = this;
            }
    
            public List<ColorInfo> AvailableColors
            {
                get
                {
                    return new List<ColorInfo>()
                    {
                        new ColorInfo() {Color = Colors.Red },
                        new ColorInfo() { Color = Colors.Green },
                        new ColorInfo() { Color = Colors.Blue },
                        new ColorInfo() { Color = Colors.Yellow }
                    };
                }
            }
    
            public Dictionary<string, ColorInfo> SelectedColors { get; private set;}
        }
    
        public class ColorInfo : INotifyPropertyChanged
        {
            private Color _color;
            public Color Color
            {
                get { return _color; }
                set 
                {
                    _color = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Color"));
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
