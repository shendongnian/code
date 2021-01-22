    public TableView Join(Table inner,
                          FakeFunc<Table, Projection> outerKeySelector,
                          FakeFunc<Table, Projection> innerKeySelector,
                          FakeFunc<Table, Table, Projection[]> resultSelector){
        Table join = new JoinedTable(this, inner,
            new EqualsCondition(outerKeySelector(this), innerKeySelector(inner)));
        return join.Select(resultSelector(this, inner));
    }
