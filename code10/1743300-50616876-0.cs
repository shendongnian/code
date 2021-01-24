    using (ApplicationDbContext db = new ApplicationDbContext())
    {
    	db.Database.ExecuteSqlCommand("TRUNCATE TABLE COCoreMembers");
    	DataAccess.DataTable abc = DataAccess.DataTable.New.ReadCsv(Server.MapPath("~/App_Data/TempBrdcepPSC/PscData/co_members.csv"));
    	bool checkColumn = false;
    	if(abc.Columns.Contains("CNIC"))
    	{
    		checkColumn = true;
    	}
    	else
    	{
    		abc.Columns.Add("CNIC");
    	}
    	
    	COCoreMember xyz = new COCoreMember();
    
    	foreach (Row Row in abc.Rows)
    	{
    		xyz._URI = Row["_URI"];
    		xyz._PARENT_AURI = Row["_PARENT_AURI"];
    		xyz.HHID = Row["HHID"];
    		xyz.HHNAME = Row["HHNAME"];
    		xyz.HH_SET_ID = Row["HH_SET_ID"];
    		xyz.HH_SET_NAME = Row["HH_SET_NAME"];
    		xyz.MEM_ID = Row["MEM_ID"];
    		xyz.MEM_NAME = Row["MEM_NAME"];
    		xyz.MEMBER_AGE = Row["MEMBER_AGE"];
    		xyz.POSITION = Row["POSITION"];
    		xyz.CELL = Row["CELL"];
    		
    		if(checkColumn)
    		{
    			xyz.CNIC = Row["CNIC"];
    		}
    		else
    		{
    			xyz.CNIC = "no record";
    		}
    
    		db.COCoreMembers.Add(xyz);
    		db.SaveChanges();
    	}
    }
