    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	W2.Owner = W1;
    	W1.IsHitTestVisible = false;
    	W2.Closing += W2_Closing;
    	W2.Show();
    }
    
    private void W2_Closing(object sender, CancelEventArgs e)
    {
    	W1.IsHitTestVisible = true;
    }
