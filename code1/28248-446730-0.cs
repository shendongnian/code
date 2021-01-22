    from a in dbReqs
    group a by new { a.AssignmentID, a.StopID }
    into pr
    select new
    {
      AssignmentID = pr.Key.AssignmentID,
      StopID = pr.Key.StopID,
      PickQty = pr.Sum(p=> p.PickedQty),
      Count = pr.Sum(c => c.ReqQty)
    }
