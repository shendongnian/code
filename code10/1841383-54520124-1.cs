        CompositeTransform TextDrag = new CompositeTransform();
        CompositeTransform savedTransform = new CompositeTransform();
        public MainPage()
        {          
            this.InitializeComponent();
            TextBlock1.RenderTransform = TextDrag;
        }
        // Copy Transform X and Y if TextBlock is within bounds
        private void CopyTransform(CompositeTransform orig, CompositeTransform copy)
        {
            copy.TranslateX = orig.TranslateX;
            copy.TranslateY = orig.TranslateY;
        }
        private void TextBlock1_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            TextDrag.TranslateX += e.Delta.Translation.X;
            TextDrag.TranslateY += e.Delta.Translation.Y;           
           
            CompositeTransform transform = TextBlock1.RenderTransform as CompositeTransform;
            // Get current Top-Left coordinates of TextBlock
            var TextTopLeft = TextBlock1.TransformToVisual(GridBounds).TransformPoint(new Point(0, 0));
            // Get current Bottom-Right coordinates of TextBlock
            var TextBottomRight = TextBlock1.TransformToVisual(GridBounds).TransformPoint(new Point(TextBlock1.ActualWidth, TextBlock1.ActualHeight));
            // Get Top-Left grid coordinates
            var GridTopLeft = (new Point(0, 0));
            // Get Bottom-Right grid coordinates
            var GridBottomRight = (new Point(GridBounds.ActualWidth, GridBounds.ActualHeight));
            if (TextTopLeft.X < GridTopLeft.X || TextBottomRight.X > GridBottomRight.X)
            {
                // Out of bounds on X axis - Revert to copied X transform
                TextDrag.TranslateX = savedTransform.TranslateX; ;
            }
            else if (TextTopLeft.Y < GridTopLeft.Y || TextBottomRight.Y > GridBottomRight.Y)
            {
                // Out of bounds on Y axis - Revert to copied Y transform
                TextDrag.TranslateY = savedTransform.TranslateY;
            }
            else
            {
                // TextBlock is within bounds - Copy X and Y Transform
                CopyTransform(transform, savedTransform);
            }
        }
