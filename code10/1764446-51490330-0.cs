        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null && e.NewElement != null)
            {
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
