    AddBox(s1, 1, 0, 3, 1, "# 1");
    AddBox(s1, 2, 1, 2, 2, "# 2");
    AddBox(s1, 4, 0, 4, 2, "# 3");
    AddBox(s1, 4, 2, 2, 2, "# 4");
    AddBox(s1, 4, 4, 1, 1, "# 5");
    int AddBox(Series s, float x, float y, float w, float h, string label)
    {
        return AddBox(s, new PointF(x, y), new SizeF(w, h), label);
    }
    int AddBox(Series s, PointF pt, SizeF sz, string label)
    {
        int i = s.Points.AddXY(pt.X, pt.Y);
        s.Points[i].Tag = sz;
        s.Points[i].Label = label;
        s.Points[i].LabelForeColor = Color.Transparent;
        s.Points[i].Color = Color.Transparent;
        return i;
    }
