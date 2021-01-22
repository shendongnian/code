    while(tabControlToClear.Controls.Count > 0)
    {
        tabControlToClear.Controls[0].Dispose();
        tabControlToClear.Controls.RemoveAt(0);
    }
