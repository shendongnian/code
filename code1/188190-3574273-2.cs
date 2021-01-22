    interface IShapePainter
    {
    	void Paint(Geometry shape);
    }
    
    static class ShapeExtensions
    {
    	public static IShapePainter GetPainter(Geometry shape)
    	{
    		if (shape is ShapeA)
    			return new ShapeAPainter();
    		// Add other painters here
    		else
    			return null;
    	}
    	public static void Paint(this Geometry shape)
    	{
    		GetPainter(shape).Paint(shape);
    	}
    }
    
    abstract class ShapePainter<T> : IShapePainter
    	where T : Geometry
    {
    	public abstract void Paint(T shape);
    
    	void IShapePainter.Paint(Geometry shape)
    	{
    		this.Paint((T)shape);
    	}
    }
    
    class ShapeAPainter : ShapePainter<ShapeA>
    {
    	public override void Paint(ShapeA shape)
    	{
    		// Your paint code
    	}
    }
