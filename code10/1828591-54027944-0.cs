    public class BooleanVisitor : QueryNodeVisitor<bool>
    {
        public override bool Visit(SingleValuePropertyAccessNode propertyNode)
        {
            if (propertyNode == null)
            {
                return false;
            }
    
            return propertyNode.TypeReference.IsBoolean();
    }
