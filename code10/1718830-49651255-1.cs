    // 1. Sub class
    public class MyBoxView : BoxView
    {
        public int Index { get; set; }
    }
    // 2. Use new sub class
    var clickableBoxv = new MyBoxView
    {
        BackgroundColor = Color.Transparent,
        Margin = new Thickness(0, 5, 0, 5)
    };
    clickableBoxv.GestureRecognizers.Add(new TapGestureRecognizer
    {
        // 3. Pass in the box rather than the int.
        Command = new Command(() => Item_Clicked(clickableBoxv)),
    });
    private void Item_Clicked(MyBoxView box)
    {
        // 4. Use the index as the number.
        DisplayAlert("Alert", box.Index.ToString(), "OK");
    }
