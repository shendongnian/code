    Button[,] gameButtons = new Button[3, 3];
    
    for (int row = 0; column <= 3; row++)
      for (int column = 0; column <= 3; column++)
      {
        Button button = new Button();
        // button...
        gameLayoutPanel.Items.Add(button);
        gameButtons[row, column] = button;
      }
