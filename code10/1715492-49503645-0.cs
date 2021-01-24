    private void FillClassMaterialsTable(DataBundle dataBundle, ref AllTblListClass dataStore)
    {
    	// Ado.Net code to call Stored Proc & fetch results
    	dataStore.MatrlObj = #List of Data of Relevant Type#
    }
    
    private void FillCoursesTable(DataBundle dataBundle, ref AllTblListClass dataStore)
    {
    	// Ado.Net code to call Stored Proc & fetch results
    	dataStore.Courses = #List of Data of Relevant Type#
    }
    
    ... // So on create simpler 15/20 methods for each Table/Stored Proc call
    
    public AllTblListClass GetDataStore(DataBundle aListBundle)
    {
    AllTblListClass result = new AllTblListClass();
     switch(aListBundle.ListType)
     {
    	case Constants.ClassSubMatRelation:
    	{
    	FillClassMaterialsTable(aListBundle, ref result);
    	}
    	break;
    	
    	case Constants.ClassCourses:
    	{
    	FillCoursesTable(aListBundle, ref result);
    	}
    	break;
     }
     return result;
    }
