    public class ColumnProperties
    {
       readonly string m_HeaderText;
       public ColumnProperties(string headerText, Color color, int width) { ... }
       public string HeaderText { get { return m_HeaderText; }
       public Color FontColor { get; set; }
       public int Width { get; set; }
       ...
    }
