    var table = new TableView();
    table.Intent = TableIntent.Settings;
    var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
    layout.Children.Add (new Label() {
        Text = "TestLayout",
        TextColor = Color.FromHex("#f35e20"),
        VerticalOptions = LayoutOptions.Center
    });
    
    table.Root = new TableRoot () {
        new TableSection("Getting Started") {
            new ViewCell() {View = layout}
        }
    };
    
    Content = table;
