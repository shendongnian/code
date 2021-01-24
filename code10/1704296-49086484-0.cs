        CanvasCommandList cl;
        CanvasBitmap image;
        bool resourcesLoaded = false;
        private void canvasControl_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {
            args.TrackAsyncAction( CreateResources( sender ).AsAsyncAction() );
        }
        private async Task CreateResources(CanvasControl sender) {
            image = await CanvasBitmap.LoadAsync( canvasControl, new Uri( "ms-appx:///Imgs/test.jpg" ) );
            int ratio = 6;
            var newImgWidth = image.Size.Width / ratio;
            var newImgHeight = image.Size.Height / ratio;
            double displayScaling = DisplayInformation.GetForCurrentView().LogicalDpi / sender.Dpi;
            double pixelWidth = newImgWidth * displayScaling;
            double pixelHeight = newImgHeight * displayScaling;
            cl = new CanvasCommandList( sender );
            using( CanvasDrawingSession clds = cl.CreateDrawingSession() ) {
                var scaleEffect = new ScaleEffect() {
                    Source = image,
                    Scale = new Vector2() {
                        X = ( float ) ( pixelWidth / image.Size.Width ),
                        Y = ( float ) ( pixelHeight / image.Size.Height ),
                    }
                };
                var blurEffect = new GaussianBlurEffect() {
                    Source = scaleEffect,
                    BlurAmount = 5f
                };
                //don't now why but we need to do this in order to have the correct bounds size
                clds.DrawImage( blurEffect, 0, 0, new Rect( 0, 0, newImgWidth, newImgHeight ), 0.05f );
                //now draw the circle
                clds.FillCircle( ( float ) newImgWidth / 2, ( float ) newImgHeight / 2,
                  ( float ) ( newImgWidth > newImgHeight ? newImgHeight : newImgWidth ) / 2,
                  new CanvasImageBrush( sender, scaleEffect ) {
                      SourceRectangle = new Rect( 0, 0, newImgWidth, newImgHeight )
                  } );
            }
            resourcesLoaded = true;
        }
        void canvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args) {
            if( resourcesLoaded ) {
                //cell (0,0)
                args.DrawingSession.DrawImage( cl,
                    0,
                    0 );
                args.DrawingSession.DrawRectangle( new Rect(
                    0, 0,
                    cl.GetBounds( sender ).Width, cl.GetBounds( sender ).Height ), Windows.UI.Colors.Red, 3 );
                //cell (0,1)
                args.DrawingSession.DrawImage( cl,
                    ( float ) ( sender.ActualWidth - cl.GetBounds( sender ).Width ),
                    ( float ) ( 0 ) );
                args.DrawingSession.DrawRectangle( new Rect(
                    ( sender.ActualWidth - cl.GetBounds( sender ).Width ), 0,
                    cl.GetBounds( sender ).Width, cl.GetBounds( sender ).Height ), Windows.UI.Colors.Green, 3 );
                //cell (1,0)
                args.DrawingSession.DrawImage( cl, ( float ) ( 0 ),
                    ( float ) ( sender.ActualHeight - cl.GetBounds( sender ).Height ) );
                args.DrawingSession.DrawRectangle( new Rect(
                    ( 0 ),
                    ( sender.ActualHeight - cl.GetBounds( sender ).Height ),
                    cl.GetBounds( sender ).Width, cl.GetBounds( sender ).Height ), Windows.UI.Colors.Yellow, 3 );
                //cell (1,1)
                args.DrawingSession.DrawImage( cl,
                    ( float ) ( sender.ActualWidth - cl.GetBounds( sender ).Width ),
                    ( float ) ( sender.ActualHeight - cl.GetBounds( sender ).Height ) );
                args.DrawingSession.DrawRectangle( new Rect(
                    ( sender.ActualWidth - cl.GetBounds( sender ).Width ),
                    ( sender.ActualHeight - cl.GetBounds( sender ).Height ),
                    cl.GetBounds( sender ).Width, cl.GetBounds( sender ).Height ), Windows.UI.Colors.Orange, 3 );
            }
        }
