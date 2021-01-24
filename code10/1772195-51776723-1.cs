    void testEmpty(Chart chart)
    {
        bool empty = true;
        foreach (var s in chart.Series)
        {
            if (s.Points.Any(x => !x.IsEmpty)) {empty = false; break; }
        }
        if (chart.Annotations.Contains(chart.Annotations["Empty"]))
            chart.Annotations.Remove(chart.Annotations["Empty"]);
        if (empty)
        {
            TextAnnotation ta = new TextAnnotation();
            ta.Name = "Empty";
            ta.X = 30;
            ta.Y = 45;
            ta.Text = "No Data!";
            ta.Font = new Font(Font.FontFamily, 30f);
            chart.Annotations.Add(ta);
        }
    }
