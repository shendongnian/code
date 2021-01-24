    private DayButton _btn1 = new DayButton(){ EventName = "FooBaar"};
    
    protected override void OnAppearing()
    {
       _btn1.Clicked += OnDayBtnClicked;
       base.OnAppearing();
    }
    
    protected override void OnDisappearing()
    {
       _btn1.Clicked -= OnDayBtnClicked;
       base.OnDisappearing();
    }
    
    private void OnDayBtnClicked(object sender, EventArgs e)
    {
    	 //What to do when a button is clicked
    }
