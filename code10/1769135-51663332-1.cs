    using System.Linq;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    namespace SampleCode
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
        
            /// <summary>
            /// Handle the user dragging the rectangle.
            /// </summary>
            private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                Thumb thumb = (Thumb)sender;
                RectangleViewModel myRectangle = (RectangleViewModel)thumb.DataContext;
                //
                // Update the the position of the rectangle in the view-model.
                //
                myRectangle.X += e.HorizontalChange;
                myRectangle.Y += e.VerticalChange;
            }
            /// <summary>
            /// Hundle the resize of the canvas
            /// </summary>
            private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                Size newSize = e.NewSize;
                ((ViewModel)this.DataContext).Rectangles.ToList().ForEach(i => i.update(e.NewSize));
            }
        }
    }
