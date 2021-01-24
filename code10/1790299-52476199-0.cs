    void Main()
    {
    	//Run this code against a blank drawing in Visio
    	var vApp = MyExtensions.GetRunningVisio();
    	
    	var vDoc = vApp.ActiveDocument;
    	var stencilDoc = vDoc.Application.Documents.OpenEx("wfctrl_m.vssx",
    													   (short)Visio.VisOpenSaveArgs.visOpenRO
    													   + (short)Visio.VisOpenSaveArgs.visOpenDocked);
    	var vPag = vApp.ActivePage;
    	
    	var diagramServices = vDoc.DiagramServicesEnabled;
    	vDoc.DiagramServicesEnabled = (int)Visio.VisDiagramServices.visServiceVersion140 
    								+ (int)Visio.VisDiagramServices.visServiceVersion150;
    	var shpList = vPag.Drop(stencilDoc.Masters.ItemU["List box"], 2.25, 9.5);
    	var itemMaster = stencilDoc.Masters.ItemU["List box item"];
    	
    	// Drop two items in - this works because the item
    	// shapes have the correct required categories ('Grid')
    	vPag.DropIntoList(itemMaster, shpList, 1);
    	vPag.DropIntoList(itemMaster, shpList, 1);
    	
    	// Now set the list's required categories to someting else
    	shpList.CellsU["User.msvSDListRequiredCategories"].FormulaU = $"\"Bob\"";
    	
    	// Note an error is thrown here because the list item being
    	// inserted does not contain the category 'Bob'
    	try
    	{	        
    		vPag.DropIntoList(itemMaster, shpList, 1);
    	}
    	catch (COMException ex) when (ex.ErrorCode == -2032465763)
    	{
    		//Inappropriate source object for this action.
    		Console.WriteLine($"{ex.Message} - check matching categories in List and ListItem shapes");
    	}
    	
    	vDoc.DiagramServicesEnabled = diagramServices;
    }
