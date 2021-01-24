    private void RemoveControls(Type type)
    {
        for (int i = TablePanel.Controls.Count - 1; i >= 0; i--)
        {
            var controlType = TablePanel.Controls[i].GetType();
            if (type.IsAssignableFrom(controlType))
                TablePanel.Controls[i].Dispose();
        }
    }
