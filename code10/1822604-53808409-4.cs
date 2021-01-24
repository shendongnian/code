    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using app1;
    using app1.iOS;
    using UIKit;
    using Foundation;
    [assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
    namespace app1.iOS
    {
      public class MyEntryRenderer:EntryRenderer,IUITextFieldDelegate
      {
        public MyEntryRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                Control.WeakDelegate = this;                       
            }
               
        }
        [Export("textFieldShouldBeginEditing:")]
        public bool ShouldBeginEditing(UITextField textField)
        {
            MessagingCenter.Send<Object>(this, "finish");
            return false;
        }
      }
    }
