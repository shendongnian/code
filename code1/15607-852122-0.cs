    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using Microsoft.VirtualEarth.MapControl;
    
    namespace MapInfo
    {
        public partial class Page : UserControl
        {
            /// <summary>
            /// Sample drawing a polyline on a Virtual Earth map
            /// </summary>
            public Page()
            {
                InitializeComponent();
                VEMap.MouseLeftButtonUp += new MouseButtonEventHandler(VEMap_MouseLeftButtonDown);
                VEMap.MouseLeave += new MouseEventHandler(VEMap_MouseLeave);
            }
    
            MapPolyline polyline = null;
    
            /// <summary>
            /// Ends drawing the current polyline
            /// </summary>
            void VEMap_MouseLeave(object sender, MouseEventArgs e)
            {
                polyline = null;
            }
            /// <summary>
            /// Start or add-to a polyline
            /// </summary>
            private void VEMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                Map m = (Map)sender;
    
                Location l = m.ViewportPointToLocation(e.GetPosition(m));
    
                if (polyline == null)
                {
                    CreateNewPolyline(l);
                }
                else
                {
                    polyline.Locations.Add(l);
                }
            }
            /// <summary>
            /// Create a new MapPolyline
            /// </summary>
            /// <param name="startPoint">starting Location</param>
            private void CreateNewPolyline(Location startPoint)
            {
                polyline = new MapPolyline();
                polyline.Stroke = new SolidColorBrush(Colors.Red);
                polyline.StrokeThickness = 2;
                var lc = new LocationCollection();
                lc.Add(startPoint);
                polyline.Locations = lc;
                VEMap.Children.Add(polyline);
            }
        }
    }
