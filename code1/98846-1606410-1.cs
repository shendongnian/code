    [XmlRoot(Namespace = "")]
    public class Data
    {
    	public int MaxCount;
    	public Point[] Points;
    }
    
    public class Point
    {
    	[XmlAttribute]
    	public int X;
    	[XmlAttribute]
    	public int Y;
    }
