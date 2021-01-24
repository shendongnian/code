    private Task ObtenerDatosd()
    {
        string text = SearcInterno.Text.ToLower();
        return Task.Run(() =>
        {
            for (int i = draw2.Count - 1; i >= 0; i--)
            {
                if(draw2[i].ToString().ToLower().Contains(text))
                {
                    //action
                    System.Windows.MessageBox.Show("Code action");
                }
            }
        });
    }
