    protected override void OnAppearing() {
    
      base.OnAppearing();
    
      float speed = MainPage.acceleration;
      
      if (speed < 0)
      {
        speed = speed * (-1);
      }
      Value.Text = speed.ToString()
    }
