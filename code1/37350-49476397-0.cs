    var joinColT1 = table1.Columns["ID"];
    var joinColT2 = table2.Columns["FK_IDT1"];
    var rel1 = new DataRelation("R1To2", joinColT1, joinColT2, false);
    var rel2 = new DataRelation("R2To1", joinColT2, joinColT1, false);
    theDataSet.Relations.Add(rel1);
    theDataSet.Relations.Add(rel2);
    // Add the column you're after
    var hisFriend = new DataColumn("HisFriend", typeof(string), "Parent([R2To1]).[HisFriend]");
    table1.Columns.Add(hisFriend);
    // Add a back-reference to the other table against the friend if you want, too
    var hisFriendsSalary = new DataColumn("HisFriendsSalary", typeof(decimal) "Parent([R1To2]).[Salary]");
    table2.Columns.Add(hisFriendsSalary);
