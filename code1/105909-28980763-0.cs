    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace yournamespace
    {
        public partial class YourUserControl : UserControl
        {
          private static double org_width = 77.6;//desired width
          private static double org_height = 81.4;//desired height
         private static double org_ratio = org_width / org_height; // width/height
       
         public YourUserControl()
         {
             InitializeComponent();
         }
         private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
         {
              FrameworkElement UCborder = this;
              UCborder.Width = UCborder.Height*org_ratio;
         }
      }
    }
