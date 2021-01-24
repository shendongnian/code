    public IList<Stripe> StripeCollection {
      get { return _stripeCollection; }
      set {
        _stripeCollection = value;
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StripeCollection)));
      }
    } 
    private IList<Stripe> _stripeCollection=MyZebra.Stripes;
    
    MyZebra.StripesChanged += (sender, args) => {var tmpCol=StripeCollection; StripeCollection=null; StripeCollection=tmpCol;};
	
