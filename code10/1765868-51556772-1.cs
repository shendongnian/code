    using MyProject.iOS.Renderers;
    using CoreGraphics;
    using Foundation;
    using System;
    using System.Linq;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    [assembly: ExportRenderer(typeof(Slider), typeof(ClickableSliderRenderer))]
    namespace MyProject.iOS.Renderers
    {
    public class ClickableSliderRenderer : SliderRenderer
    {
        UILongPressGestureRecognizer uiTap;
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            
            uiTap = new UILongPressGestureRecognizer(Tapped);
            uiTap.MinimumPressDuration = 0;
            AddGestureRecognizer(uiTap);
        }
        private void Tapped(object sender)
        {
            CGPoint point = uiTap.LocationInView(this);
            nfloat thumbWidth = Control.Subviews.LastOrDefault().Bounds.Size.Width;
            nfloat value;
            if (point.X <= thumbWidth / 2.0)
                value = Control.MinValue;
            else if (point.X >= Control.Bounds.Size.Width - thumbWidth / 2)
                value = Control.MaxValue;
            else
            {
                var percentage = ((point.X - thumbWidth / 2) / (Control.Bounds.Size.Width - thumbWidth));
                var delta = percentage * (Control.MaxValue - Control.MinValue);
                value = Control.MinValue + delta;
            }
            if (uiTap.State == UIGestureRecognizerState.Began)
            {
                UIView.Animate(0.35, delay: 0, options: UIViewAnimationOptions.CurveEaseInOut, animation:
                    () =>
                    {
                        Control.SetValue((float)value, true);
                        Control.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    }, completion: null);
            }
            else if (uiTap.State == UIGestureRecognizerState.Changed)
            {
                Control.SetValue((float)value, false);
                Control.SendActionForControlEvents(UIControlEvent.ValueChanged);
            }
            else
            {
                Control.SetValue((float)value, false);
            }
            Control.ThumbRectForBounds(Bounds, Bounds, (float)value);
        }
    }
    }
