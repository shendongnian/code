    public class UnanimatedButtonRenderer : ButtonRenderer
    {
        private FlatButton TypedElement => this.Element as FlatButton;
        public UnanimatedButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null && e.NewElement != null)
            {
                this.UpdateBackground();
                if (Build.VERSION.SdkInt > BuildVersionCodes.Lollipop)
                {
                    this.Control.StateListAnimator = null;
                }
                else
                {
                    this.Control.Elevation = 0;
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(VisualElement.BackgroundColorProperty.PropertyName) ||
                e.PropertyName.Equals(Button.CornerRadiusProperty.PropertyName) ||
                e.PropertyName.Equals(Button.BorderWidthProperty.PropertyName))
            {
                this.UpdateBackground();
            }
        }
        private void UpdateBackground()
        {
            if (this.TypedElement != null)
            {
                using (var background = new GradientDrawable())
                {
                    background.SetColor(this.TypedElement.BackgroundColor.ToAndroid());
                    background.SetStroke((int)Context.ToPixels(this.TypedElement.BorderWidth), this.TypedElement.BorderColor.ToAndroid());
                    background.SetCornerRadius(Context.ToPixels(this.TypedElement.CornerRadius));
                    // customize the button states as necessary
                    using (var backgroundStates = new StateListDrawable())
                    {
                        backgroundStates.AddState(new int[] { }, background);
                        this.Control.SetBackground(backgroundStates);
                    }
                }
            }
        }
    }
