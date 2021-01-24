    private void SetToolTipText()
    {
        var content = string.Empty;
        foreach (var item in listBox1.Items)
        {
            var first3 = item.ToString().Substring(0, 3);
            content += first3 + Environment.NewLine;
        }
        toolTip.SetToolTip(listBox1, content);
    }
