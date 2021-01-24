    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using AgentOctal.WpfLib;
    
    namespace VmBindingExample
    {
        using System.Windows.Media;
    
        public class MainWindowVm : ViewModel
        {
            private string _text;
    
            public string Text
            {
                get
                {
                    return _text;
                }
    
                set
                {
                    SetValue(ref _text, value);
                    byte red = (byte)(255 / 10 * (10 - _text.Length));
                    BackgroundColor = new SolidColorBrush(Color.FromArgb(255, red, 255, 255));
                }
            }
    
            private Brush _backgroundColor;
    
            public Brush BackgroundColor
            {
                get
                {
                    return _backgroundColor;
                }
    
                set
                {
                    SetValue(ref _backgroundColor, value);
                }
            }
        }
    }
