    private bool closeStoryBoardCompleted = false;
    private void Window_Closing(object sender, CancelEventArgs e)
    {
        if (!closeStoryBoardCompleted)
        {
            closeStoryBoard.Begin();
            e.Cancel = true;
        }
    }
    
    private void closeStoryBoard_Completed(object sender, EventArgs e)
    {
        closeStoryBoardCompleted = true;
        this.Close();
    }
