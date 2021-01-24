    private Random rand = new Random();
    private Color[] colors = new Color[]
    {
        Color.Red,
        Color.Blue,
        Color.Green
    }    
    private void But0_0_Click(object sender, RoutedEventArgs e)
    {    
        for (int i = 1; i <= 20; i++)
        {
            var ele = MainGrid.FindName("But0_" + i);
            Button button = ele as Button;
            
            if (button != null)
            {
                Change_color(button);
            }
        }
    }
    private void Change_color(Button name)
    {
        name.Background= new SolidColorBrush(colors[rand.Next(0, 3)]);
    }
