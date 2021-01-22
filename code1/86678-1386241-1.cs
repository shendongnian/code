    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    namespace ImageEditor
    {
        public partial class TestControl : UserControl
        {
            private bool _tooltipVisible = false;
            public TestControl()
            {
                InitializeComponent();
            }
    
            private void theImage_MouseMove(object sender, MouseEventArgs e)
            {
                if (_tooltipVisible)
                {
                    tt.SetValue(Canvas.TopProperty, e.GetPosition(theImage).Y - (5 + txtTooltip.Height));
                    tt.SetValue(Canvas.LeftProperty, e.GetPosition(theImage).X - 5);
                }
            }
    
            private void theImage_MouseEnter(object sender, MouseEventArgs e)
            {
                _tooltipVisible = true;
                tt.Visibility = Visibility.Visible;
            }
    
            private void theImage_MouseLeave(object sender, MouseEventArgs e)
            {
                _tooltipVisible = false;
                tt.Visibility = Visibility.Collapsed;
            }
        }
    }
