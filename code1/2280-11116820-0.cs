    public static class Extensions {
        ...
        public static XmlNode RemoveFromParent(this XmlNode node) {
            return (node == null) ? null : node.ParentNode.RemoveChild(node);
        }
    }
    ...
    //some_long_node_expression.parentNode.RemoveChild(some_long_node_expression);
    some_long_node_expression.RemoveFromParent();
