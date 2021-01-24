    // 1. A place to store the boxes.
    IList<BoxView> boxes = new List<BoxView>();
    var clickableBoxv = new BoxView
    {
        BackgroundColor = Color.Transparent,
        Margin = new Thickness(0, 5, 0, 5)
    };
    // 2. Keep track of your clickable boxes.
    boxes.Add(clickableBoxv);
    clickableBoxv.GestureRecognizers.Add(new TapGestureRecognizer
    {
        // 3. Pass in the box rather than the int.
        Command = new Command(() => Item_Clicked(clickableBoxv)),
    });
    private void Item_Clicked(BoxView box)
    {
        // 4. Use the index as the number.
        DisplayAlert("Alert", boxes.IndexOf(box).ToString(), "OK");
    }
