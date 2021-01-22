    private void EmptyLabelArray()
    {
        var fmt = "Label_Row{0:00}_Col{0:00}";
        for (var rowIndex = 0; rowIndex < 100; rowIndex++)
        {
            for (var colIndex = 0; colIndex < 100; colIndex++)
            {
                var lblName = String.Format(fmt, rowIndex, colIndex);
                foreach (var ctrl in this.Controls)
                {
                    var lbl = ctrl as Label;
                    if ((lbl != null) && (lbl.Name == lblName))
                    {
                        lbl.Text = null;
                    }
                }
            }
        }
    }
