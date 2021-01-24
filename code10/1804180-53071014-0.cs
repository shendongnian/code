      IEnumerable<DataRow> s = importTable.AsEnumerable();
      IEnumerable<DataRow> t = s
          .OrderBy(r => r["HALL"]);
      IEnumerable<DataRow> sortedTable = t
          .OrderBy(r => 
                  { //if (r["ID"] is DBNull)
                    //  return "";
                    //else
                      return r["ID"]; // ERROR
                  });
      IEnumerable<DataRow> tue = sortedTable.Where(r => r["DAY"].Equals("TUE"));
      IEnumerable<DataRow> wed = sortedTable.Where(r => r["DAY"].Equals("WED"));
      AssignSections(tue);
      AssignSections(wed);
