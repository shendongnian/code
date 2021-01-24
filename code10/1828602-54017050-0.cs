    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using app1;
    using app1.iOS;
    using UIKit;
    using Foundation;
    using CoreGraphics;
    using ObjCRuntime;
    [assembly:ExportRenderer(typeof(MyPage1),typeof(MyPageRenderer))]
    namespace app1.iOS
    {
      public class MyPageRenderer:PageRenderer
      {
        public MyPageRenderer()
        {
        }
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (ViewController != null)
            {
               NSArray items = NSArray.FromStrings(new string[] { "Courses", "Favourite", "Recent" });
               UISegmentedControl segmentedControl = new UISegmentedControl(items)
               {
                  Frame = new CGRect(50, 20, NativeView.Bounds.Width - 100, 35)
               };
               segmentedControl.SelectedSegment = 0;
               segmentedControl.TintColor = UIColor.Red;
               segmentedControl.ApportionsSegmentWidthsByContent = true; //Change the width of the segment based on the content of the segment
               segmentedControl.AddTarget(this, new Selector("ValueChanged:"), UIControlEvent.ValueChanged);
               NativeView.AddSubview(segmentedControl);
            }
        }
        [Export("ValueChanged:")]
        void ValueChanged(UISegmentedControl sender)
        {
           MessagingCenter.Send<Object, int>(this, "ClickSegmentedControl", (int)sender.SelectedSegment);
            // switch((int)sender.SelectedSegment){
            //  case 0:
            //      break;
            //  case 1:
            //      break;
            //  case 2:
            //      break;
            //  default:
            //      break;
            //}
         }
      }
    }
