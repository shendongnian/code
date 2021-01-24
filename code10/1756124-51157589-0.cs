    public class RoundCornerСellRenderer : CellRenderer
    {
    	public RoundCornerСellRenderer(Cell modelElement) : base(modelElement)
    	{
    	}
    
    	public override IRenderer GetNextRenderer() =>
    		new RoundCornerСellRenderer((Cell)GetModelElement());
    
    	protected override Rectangle ApplyMargins(Rectangle rect, UnitValue[] margins, bool reverse)
    	{
    		var values = margins.Select(x => x.GetValue()).ToList();
    		return rect.ApplyMargins(values[0], values[1], values[2], values[3], reverse);
    	}
    
    	public override void DrawBackground(DrawContext drawContext)
    	{
    		// Apply the margins
    		var area = ApplyMargins(GetOccupiedAreaBBox(), GetMargins(), false);
    
    		// Get background color
    		var background = GetProperty<Background>(Property.BACKGROUND);
    		var color = background.GetColor();
    
    		// Draw the rectangle with rounded corners
    		var canvas = drawContext.GetCanvas();
    		canvas.SaveState();
    		canvas.RoundRectangle(area.GetX(), area.GetY(), area.GetWidth(), area.GetHeight(), 5);
    		canvas.SetFillColor(color);
    		canvas.Fill();
    		canvas.RestoreState();	
    	} 
    }
