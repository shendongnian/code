    class MyForm : Form
    {
    :
    List<Panel> m_panels = new List<Panel>();
    List<Point> m_points = new List<Point>();
    Size m_originalSize;
    IEnumerable<Panel> FindPanels()
    {
        foreach(var control in Controls)
        {
            Panel panel = control as Panel;
            if (panel != null)
                yield return panel;
        }
    }
    void SnapshotOriginalLayout()
    {
        m_originalSize = ClientSize; 
        foreach(var panel in FindPanels())
        {
            m_panels.Add(panel);
            m_points.Add(panel.Location);
            m_points.Add(new Point(panel.Size));
        }
    }
    Point [] GetTransformedPoints()
    {
        var points = m_points.ToArray();
        Matrix m = new Matrix();
        m.Scale(ClientSize.Width / (float) m_originalSize.Width,
                ClientSize.Height / (float) m_originalSize.Height);
        m.Transform(points);
        return points;
    }
    void ApplyTransformedPoints(Point [] points)
    {
        int index = 0;
        foreach(var panel in m_panels)
        {
            panel.Bounds = new Rectangle(points[index],
                                         new Size(points[index + 1]));
            index += 2;
        }
    }
    void ResizePanels()
    {
        if (m_originalSize.Width == 0 ||
            m_originalSize.Height == 0)
            return;
        ApplyTranformedPoints(GetTranformedPoints());
    }
    protected override void OnShown(EventArgs e)
    {
        SnapshotOriginalLayout();
        base.OnShown(e);
    }
    protected override void OnResizeEnd(EventArgs e)
    {
        base.OnResizeEnd(e);
        RescalePanels();
    }
    :
    }
