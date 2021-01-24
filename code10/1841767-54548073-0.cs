    private static string getWhereClause(BinaryOperatorNode node)
    {
        // PARSE FILTER CLAUSE
        // Parsing a filter, e.g. /Users?$filter=Id eq '1' or Id eq '100'  
        var s = "";
        if (node.Left is SingleValuePropertyAccessNode && node.Right is ConstantNode)
        {
            var property = node.Left as SingleValuePropertyAccessNode ?? node.Right as SingleValuePropertyAccessNode;
            var constant = node.Left as ConstantNode ?? node.Right as ConstantNode;
            if (property != null && property.Property != null && constant != null && constant.Value != null)
            {
                s += $" {property.Property.Name} {getStringValue(node.OperatorKind)} '{constant.Value}' ";
            }
        }
        else
        {
            if (node.Left is BinaryOperatorNode)
                s += getWhereClause(node.Left as BinaryOperatorNode);
            if (node.Right is BinaryOperatorNode)
            {
                s += $" {getStringValue(node.OperatorKind)} ";
                s += getWhereClause(node.Right as BinaryOperatorNode);
            }
        }
        return s;
    }
