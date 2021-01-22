    TableB b = new TableB();
    context.TableB.InsertOnSubmit(b);
    context.SubmitChanges();
    TableA a = new TableA();
    a.TableBID = b.TableBID;
    context.TableA.InsertOnSubmit(a);
    context.SubmitChanges();
