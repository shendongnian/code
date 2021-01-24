    public static class NodeFactory {
        public Node CreateNode(byte[] value) {
            return new ANode { internalValue = value };
        }
    
        public Node CreateNode(int value) {
            return new BNode { internalValue = value };
        }
    }
