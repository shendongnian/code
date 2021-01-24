    int point=0;
    .
    .
    .
    //after you find button view by ID
    btn.Click+= delegate {
     tv.Text=point++;
     ShowToastMethod();
         };
    public void ShowToastMethod()
        {
            Toast.MakeText(this, "mymessage ", ToastLength.Long).Show();
        }
