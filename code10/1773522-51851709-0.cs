    var hasBeenAssembled = db.Assembleds
                           .AsNoTracking()
                           .Where(x => x.ProductionPlanId == (long)_currentPlan.ProductionPlan);
    var qry = db.AssemblyListItems
              .AsNoTracking()
              .Where(x => x.ProductionPlanID == (long)_currentPlan.ProductionPlan)
              .Where(ali => !hasBeenAssembled.Any(hba => hba.DocumentId == ali.DocumentNo && hba.KitHeaderId == ali.ItemCode && hba.ProductionPlanId == ali.ProductionPlanID))
              .ToList();
    olvData.SetObjects(qry); 
