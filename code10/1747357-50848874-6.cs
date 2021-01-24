    public class CustomEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<CustomEntry, TextInputLayout>
    {
        public CustomEntryRenderer (Context context) : base(context)
        {
        }
        protected EditText EditText => Control.EditText;
        protected override TextInputLayout CreateNativeControl()
        {
            var textInputLayout = new TextInputLayout(Context);
            var editText = new AppCompatEditText(Context);
            editText.SetTextSize(ComplexUnitType.Sp, (float)Element.FontSize);
            textInputLayout.AddView(editText);
            return textInputLayout;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<XfxEntry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var ctrl = CreateNativeControl();
                SetNativeControl(ctrl);
                var activeColor = Element.ActiveHintTextColor.ToAndroid(global::Android.Resource.Attribute.ColorAccent, Context);
                var hintText = Control.Class.GetDeclaredField("mFocusedTextColor");
                hintText.Accessible = true;
                hintText.Set(Control, new ColorStateList(new int[][] { new[] { 0 } }, new int[] { activeColor }));
                EditText.Enabled = Element.IsEnabled;
                Control.Hint = Element.Placeholder;
                EditText.SetTextColor(Element.TextColor.ToAndroid());
            }
        }
    }
