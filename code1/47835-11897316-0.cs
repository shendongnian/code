    public class ImageViewControl : Border
    {
        private Point origin;
        private Point start;
        private Image image;
        public ImageViewControl()
        {
            ClipToBounds = true;
            Loaded += OnLoaded;
        }
        #region ImagePath
        /// <summary>
        ///     ImagePath Dependency Property
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof (string), typeof (ImageViewControl), new FrameworkPropertyMetadata(string.Empty, OnImagePathChanged));
        /// <summary>
        ///     Gets or sets the ImagePath property. This dependency property 
        ///     indicates the path to the image file.
        /// </summary>
        public string ImagePath
        {
            get { return (string) GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        /// <summary>
        ///     Handles changes to the ImagePath property.
        /// </summary>
        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ImageViewControl) d;
            var oldImagePath = (string) e.OldValue;
            var newImagePath = target.ImagePath;
            target.ReloadImage(newImagePath);
            target.OnImagePathChanged(oldImagePath, newImagePath);
        }
        /// <summary>
        ///     Provides derived classes an opportunity to handle changes to the ImagePath property.
        /// </summary>
        protected virtual void OnImagePathChanged(string oldImagePath, string newImagePath)
        {
        }
        #endregion
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            image = new Image {
                                  //IsManipulationEnabled = true,
                                  RenderTransformOrigin = new Point(0.5, 0.5),
                                  RenderTransform = new TransformGroup {
                                                                           Children = new TransformCollection {
                                                                                                                  new ScaleTransform(),
                                                                                                                  new TranslateTransform()
                                                                                                              }
                                                                       }
                              };
            // NOTE I use a border as the first child, to which I add the image. I do this so the panned image doesn't partly obscure the control's border.
            // In case you are going to use rounder corner's on this control, you may to update your clipping, as in this example:
            // http://wpfspark.wordpress.com/2011/06/08/clipborder-a-wpf-border-that-clips/
            var border = new Border {
                                        IsManipulationEnabled = true,
                                        ClipToBounds = true,
                                        Child = image
                                    };
            Child = border;
            image.MouseWheel += (s, e) =>
                                    {
                                        var zoom = e.Delta > 0
                                                       ? .2
                                                       : -.2;
                                        var position = e.GetPosition(image);
                                        image.RenderTransformOrigin = new Point(position.X / image.ActualWidth, position.Y / image.ActualHeight);
                                        var st = (ScaleTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is ScaleTransform);
                                        st.ScaleX += zoom;
                                        st.ScaleY += zoom;
                                        e.Handled = true;
                                    };
            image.MouseLeftButtonDown += (s, e) =>
                                             {
                                                 if (e.ClickCount == 2)
                                                     ResetPanZoom();
                                                 else
                                                 {
                                                     image.CaptureMouse();
                                                     var tt = (TranslateTransform) ((TransformGroup) image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                                                     start = e.GetPosition(this);
                                                     origin = new Point(tt.X, tt.Y);
                                                 }
                                                 e.Handled = true;
                                             };
            image.MouseMove += (s, e) =>
                                   {
                                       if (!image.IsMouseCaptured) return;
                                       var tt = (TranslateTransform) ((TransformGroup) image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                                       var v = start - e.GetPosition(this);
                                       tt.X = origin.X - v.X;
                                       tt.Y = origin.Y - v.Y;
                                       e.Handled = true;
                                   };
            image.MouseLeftButtonUp += (s, e) => image.ReleaseMouseCapture();
            //NOTE I apply the manipulation to the border, and not to the image itself (which caused stability issues when translating)!
            border.ManipulationDelta += (o, e) =>
                                           {
                                               var st = (ScaleTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is ScaleTransform);
                                               var tt = (TranslateTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                                               st.ScaleX *= e.DeltaManipulation.Scale.X;
                                               st.ScaleY *= e.DeltaManipulation.Scale.X;
                                               tt.X += e.DeltaManipulation.Translation.X;
                                               tt.Y += e.DeltaManipulation.Translation.Y;
                                               e.Handled = true;
                                           };
        }
        private void ResetPanZoom()
        {
            var st = (ScaleTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is ScaleTransform);
            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            st.ScaleX = st.ScaleY = 1;
            tt.X = tt.Y = 0;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
        }
        /// <summary>
        /// Load the image (and do not keep a hold on it, so we can delete the image without problems)
        /// </summary>
        /// <see cref="http://blogs.vertigo.com/personal/ralph/Blog/Lists/Posts/Post.aspx?ID=18"/>
        /// <param name="path"></param>
        private void ReloadImage(string path)
        {
            try
            {
                ResetPanZoom();
                // load the image, specify CacheOption so the file is not locked
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                bitmapImage.EndInit();
                image.Source = bitmapImage;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
