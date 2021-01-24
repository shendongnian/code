    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	var vPag = vApp.ActivePage;
    	
    	var graphShp = vPag.Shapes.Cast<Visio.Shape>()
    				   .FirstOrDefault(s => s.Master?.Name == "Graph");
    	if (graphShp != null)
    	{
    		var dotMst = vPag.Document.Masters["Dot"];
    		
    		//Get x / y back as a named tuple
    		var origin = GetGraphOrigin(graphShp);
    		
    		//Green fill is the default defined in the master
    		var greenDotShp = vPag.Drop(dotMst, origin.x, origin.y);
    		
    		//Use offest based on graph origin
    		var redDotOffsetX = -0.5;
    		var redDotOffsetY = 0.25;
    		var redDotShp = vPag.Drop(dotMst, origin.x + redDotOffsetX, origin.y + redDotOffsetY);
    		redDotShp.CellsU["FillForegnd"].FormulaU = "RGB(200,40,40)";
    	}
    }
    
    private (double x, double y) GetGraphOrigin(Visio.Shape targetShp) 
    {
    	const string originX = "User.OriginOnPageX";
    	const string originY = "User.OriginOnPageY";
    	
    	if (targetShp == null)
    	{
    		throw new ArgumentNullException();
    	}
    	if (targetShp.CellExistsU[originX, (short)Visio.VisExistsFlags.visExistsAnywhere] != 0
    		&& targetShp.CellExistsU[originY, (short)Visio.VisExistsFlags.visExistsAnywhere] != 0)
    	{
    		return (x: targetShp.CellsU[originX].ResultIU, 
    				y: targetShp.CellsU[originY].ResultIU);
    	}
    	return default;
    }
