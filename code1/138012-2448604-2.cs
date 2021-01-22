    var resultSet =
        (from o in _entities.Table1.Include("Table2")
         where o.Table2.Table3.SomeColumn == SomeProperty
         select o
        ).First();
    SelectedItem = resultSet.Table2.SomeOtherColumn;
