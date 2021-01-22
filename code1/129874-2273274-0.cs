    IEnumerable<MyData> = GetMyData();
    foreach( MyData thisData in GetMyData() )
    {
        MyControl thisControl = new MyControl();
        thisControl.Dock = Left; // Or right, if you prefer
        thisControl.Value = thisData;
        panel1.Controls.Add( thisControl ); // Where panel1 is a Panel that represents the container for the scrolling-ness
    }
