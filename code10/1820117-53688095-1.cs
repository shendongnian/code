    private void MainTimer_Tick(object sender, EventArgs e)
    {
        if (System.Windows.Input.Keyboard.IsKeyDown(key))
        {
            MessageBox.Show("Success !")
        }
    }
