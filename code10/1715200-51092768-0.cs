    UnionType unionType = new TypeA();
    
    Integer count = unionType.when(new UnionType.Cases<Integer>() {
        @Override
        public Integer handleCase(TypeA typeA) {
            // TypeA-specific handling code
        }
        @Override
        public Integer handleCase(TypeB typeB) {
            // TypeB-specific handling code
        }
    });
