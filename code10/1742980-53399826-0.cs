    protected override void OnBindingContextChanged()
        {
            if (BindingContext == null)
            {
                return;
            }
            base.OnBindingContextChanged();
            SNavigationPage.SetNavContent(this, new LogoHeader()
            {
                BindingContext = BindingContext,
            });
        }
