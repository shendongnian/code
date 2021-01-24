    var stats = db.Status.Select(s => s.Status1);
    viewModel.Statuses = new SelectList(stats);
      {
                
         if (!String.IsNullOrEmpty(status))
            {
               aPPET1 = aPPET1.Where(t => t.Status.Status1.Contains(status));
            }
      }
