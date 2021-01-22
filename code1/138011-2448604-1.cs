    var resultSet =
        (from o in _entities.Table1
         where o.Table2.Table3.SomeColumn == SomeProperty
         select o
        ).First();
    SelectedItem = resultSet.Table2.SomeOtherColumn;
