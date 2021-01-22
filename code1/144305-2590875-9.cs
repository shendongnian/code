    class IntermediateJoin<T>{
        readonly JoinedTable table;
        readonly T           aliases;
    
        public IntermediateJoin(JoinedTable table, T aliases){
            this.table   = table;
            this.aliases = aliases;
        }
    
        public TableView Join(Table inner,
                              FakeFunc<T, Projection> outerKeySelector,
                              FakeFunc<Table, Projection> innerKeySelector,
                              FakeFunc<T, Table, Projection[]> resultSelector){
            var join = new JoinedTable(table, inner,
                new EqualsCondition(outerKeySelector(aliases), innerKeySelector(inner)));
            return join.Select(resultSelector(aliases, inner));
        }
        public IntermediateJoin<U> Join<U>(Table inner,
                                           FakeFunc<T, Projection> outerKeySelector,
                                           FakeFunc<Table, Projection> innerKeySelector,
                                           FakeFunc<T, Table, U> resultSelector){
            var join = new JoinedTable(table, inner,
                new EqualsCondition(outerKeySelector(aliases), innerKeySelector(inner)));
            var newAliases = resultSelector(aliases, inner);
            return new IntermediateJoin<U>(join, newAliases);
        }
    }
