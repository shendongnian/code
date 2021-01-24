    private void ToolStripMenuItemDrawBoard_Click(object sender, EventArgs e)
    {
        //Prevents errors using try catch method
        Graphics paper = pictureBoxDisplay.CreateGraphics();
        try
        {
            int boardSize = int.Parse(ToolStripTextBoxBoardSize.Text);
    
            if (boardSize > MIN_BOARD_SIZE || boardSize < MAX_BOARD_SIZE)
            {
                // Pass your board size to DrawRow()
                DrawRow(boardSize);
            }
            else
            {
                // ..
            }
        }
    }
    
    // Declare your parameter (int boardsize)
    public void DrawRow(int boardSize)
    {
        // boardSize accessable here
    }
