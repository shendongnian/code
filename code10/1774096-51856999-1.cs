    List<tblList1> List1 = new List<tblList1>();
    //TODO: please, check types; it seems that it should be List<tblList1> List2
    List<tblList2> List2 = new List<tblList2>();
    foreach (var item in new XPQuery<tblList1>(session).Where(w => w.UserID != null)) {
      if (YourConditionHere)
        List1.Add(item); // <- Condition met: to List1 
      else
        List2.Add(item); // <- Not met: "delete" form (not add) List1 into List2 
    }
