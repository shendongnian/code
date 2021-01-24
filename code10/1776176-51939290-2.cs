    var list = officeGroups.Select(og => new 
                                         {
    										Offices = og.Select(o => new OfficeNode(o.office_name,
    																				this,
    																				this,
    																				og,
    																				etc.))
    									 }
    						.SelectMany(x => x.Offices)
    						.ToList();
