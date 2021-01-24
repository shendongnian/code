    using System;
    using CoreAnimation;
    using MyApp.iOS.CustomRenderers;
    using Foundation;
    using MyApp.Controls;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    [assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
    namespace MyApp.iOS.CustomRenderers
    {
        public class CustomFrameRenderer : FrameRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
            {
                base.OnElementChanged(e);
                if (Element != null)
                {
                    var element = Element as CustomFrame;
                    int result = 0;
                    if (element.CornerRadiusTopLeft)
                        result += (int)CACornerMask.MinXMinYCorner;
                    if (element.CornerRadiusTopRight)
                        result += (int)CACornerMask.MaxXMinYCorner;
                    if (element.CornerRadiusBottomLeft)
                        result += (int)CACornerMask.MinXMaxYCorner;
                    if (element.CornerRadiusBottomRight)
                        result += (int)CACornerMask.MaxXMaxYCorner;
                    Layer.MaskedCorners = (CACornerMask)result;
                };
            }
        }
    }
