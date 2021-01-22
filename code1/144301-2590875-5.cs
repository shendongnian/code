    public Table Join<T>(Table inner,
                         FakeFunc<Table, Projection> otherKeySelector,
                         FakeFunc<Table, Projection> innerKeySelector,
                         FakeFunc<Table, Table, T> resultSelector){
        Table join = new JoinedTable(this, inner,
            new EqualsCondition(outerKeySelector(this), innerKeySelector(inner)));
        // calling resultSelector(this, inner) would give me the anonymous type,
        // but what would I do with it?
        return join;
    }
