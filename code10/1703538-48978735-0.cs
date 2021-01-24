    private void RemoveControls<T>() where T : Control
    {
        for (int i = TablePanel.Controls.Count - 1; i >= 0; i--)
        {
            if (TablePanel.Controls[i] is T)
                TablePanel.Controls[i].Dispose();
        }
    }
