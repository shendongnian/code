    Expression<Func<DatabaseAccess.Maintenance, bool>> activePlanPredicate = plan => plan.CancelDate == null && plan.UpgradeDate == null;
    var result = from subAccount in db.SubAccounts
             select new ServiceTicket
             {
                 MaintenancePlans = subAccount.Maintenances.Where(activePlanPredicate).Select(plan => plan.ToString()).ToArray()
                 // Set other properties...
             };
