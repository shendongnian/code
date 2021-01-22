    private void button1_Click(object sender, RoutedEventArgs e)
    {
            int i = 0;
    
            while (i < 500)
            {
                label1.Content = i.ToString();
                System.Threading.Thread.Sleep(2000);
                Application.DoEvents();
                ++i;
            }
     }
