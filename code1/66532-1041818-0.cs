    var map =   from bac in BAC_Maps
    			join a in Agencies on bac.Agency_ID equals a.Agency_ID
    			join b in BusinessUnits on bac.Business_Unit_ID equals b.Business_Unit_ID
    			join c in Clients on bac.Client_ID equals c.Client_ID
    			select new 
    			{ 
    				AgencyID		=	a.Agency_ID,
    				BusinessUnitID	=	b.Business_Unit_ID,
    				Client			= 	c
    			};
    
    var results =   from m in map.ToList()
    				group m by m.AgencyID into g
    				select new 
    				{
    					BusinessUnits = from m2 in g
    									group m2 by m2.BusinessUnitID into g2
    									select new
    									{
    										Clients = from m3 in g2
    												select m3.Client
    									}
    				};
    
    results.Dump();
