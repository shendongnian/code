    List<StatusDetailsViewModel> statusDetails = _igniteDb.myTable.Where(a => a.actionId == actionId)
         .GroupBy(a => new { a.Status, a.ElectionGroup })
         .GroupBy(c => new { c.Key.Status})
         .Select(b => new StatusDetailsViewModel { /* <--- Here you instantiate your view model */
              Status = b.Key.Status, 
              CountNo = b.Count()}
         ).ToList();
