    void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true; //this fixes the double event fire problem.
        string name = (e.OriginalSource as Image).Tag.ToString();
        DoSomething(name);
    }
