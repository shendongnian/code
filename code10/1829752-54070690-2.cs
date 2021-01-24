    [assembly: ExportRenderer(typeof(MyPicker), typeof(MyPickerRenderer))]
    namespace xxx.iOS
    {
       public class MyPickerRenderer:PickerRenderer,IUIPickerViewDelegate,IUIPickerViewDataSource
       {
        string SelectedValue;
        public MyPickerRenderer()
        {
        }
        public nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
        public nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Element.Items.Count;
        }
        [Export("pickerView:viewForRow:forComponent:reusingView:")]
        public UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel
            {
                TextColor = UIColor.Blue,
                Text = Element.Items[(int)row].ToString(),
                TextAlignment = UITextAlignment.Center,
            };
            var picker = this.Element;
            return label;
        }
        [Export("pickerView:didSelectRow:inComponent:")]
        public void Selected(UIPickerView pickerView, nint row, nint component)
        {
            Control.Text = Element.Items[(int)row];
            SelectedValue= Element.Items[(int)row]; 
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                SelectedValue = Element.Items[0];
                UIPickerView pickerView = (UIPickerView)Control.InputView;
                pickerView.WeakDelegate = this;
                pickerView.DataSource = this;
                // get the button Done and rewrite the event
                UIToolbar toolbar = (UIToolbar)Control.InputAccessoryView;
                UIBarButtonItem done = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (object sender, EventArgs click) =>
                    {
                        Control.Text = SelectedValue;
                        toolbar.RemoveFromSuperview();
                        pickerView.RemoveFromSuperview();
                        Control.ResignFirstResponder();
                    });
                UIBarButtonItem empty = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
                toolbar.Items = new UIBarButtonItem[] { empty,done };
            }
        }
      }
    }
