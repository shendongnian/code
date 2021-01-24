    try
    {
       ProjectHelpers.DTE.UndoContext.Open("Description of operation");
       selection.Text = newText;
    }
    finally
    {
       ProjectHelpers.DTE.UndoContext.Close();
    }
