    //first get list of assembled/completed items with the _currentplan's ID:
    var  hasbeenAssembled = 
        dbCompletedPrinteds
        .AsNoTracking()
        .Where(x => x.ProductionPlanId == (long)_currentPlan.ProductionPlan)
        //note: not sure of underlying DB technology here, but this .ToList() will
        //typically cause a DB query to execute here.
        .ToList();
    //next, use that to filter the main query.
    qry = db.AssemblyListItems
        .AsNoTracking()
        .Where(x => 
            //Get current plan items
            (x.ProductionPlanID == (long)_currentPlan.ProductionPlan)
            //filter out items which are in the previous list of 'completed' ones
            && (!hasBeenAssembled.Any(hba => hba.SopLineItemId==x.SOPOrderReturnID))
        )              
        .ToList();
    
    //I don't have any idea what _query is for, it doesn't seem to be used for anything 
    //in this example...
    var _query = qry.Where(w => w.ItemCode == "EPR15CT.L01" && w.DocumentNo == "0000026590")
                    .SingleOrDefault();
    
    
