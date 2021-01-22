    foreach (BTool b in theTools){
       Button button = new Button();
       button.Title = b.Name; //or .ToString, whatever
       button.Clicked += b.ClickedEvent; //where ClickedEvent is a method in BTool that implements the interface for the Clicked event
       ToolButtons.Children.Add(button);
    }
