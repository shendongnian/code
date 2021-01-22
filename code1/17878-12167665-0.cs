    public static List<Control> ToControlsSorted(this Control panel)
    {
        var controls = panel.Controls.OfType<Control>().ToList();
        controls.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));
        return controls;
    }
