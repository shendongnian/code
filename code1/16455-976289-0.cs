    public static readonly DependencyProperty HtmlTextProperty = DependencyProperty.Register("HtmlText", typeof(string), typeof(HtmlBox));
                    
    public string HtmlText {
    	get { return (string)GetValue(HtmlTextProperty); }
    	set { SetValue(HtmlTextProperty, value); }
    }
            
    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e) {
    	base.OnPropertyChanged(e);
    	if (e.Property == HtmlTextProperty) {
    		DoBrowse();
    	}
    }
     private void DoBrowse() {
    	if (!string.IsNullOrEmpty(HtmlText)) {
    		browser.NavigateToString(HtmlText);
    	}
    }
