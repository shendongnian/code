    TableB b = new TableB();
    context.TableB.InsertOnSubmit(b);
    TableA a = new TableA();
    a.TableB = b;
    context.TableA.InsertOnSubmit(a);
    context.SubmitChanges();
