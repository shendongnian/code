    UnionType unionType = new TypeA();
    
    Integer count = unionType.when(new UnionType.Cases<Integer>() {
        @Override
        public Integer is(TypeA typeA) {
            // TypeA-specific handling code
        }
        @Override
        public Integer is(TypeB typeB) {
            // TypeB-specific handling code
        }
    });
