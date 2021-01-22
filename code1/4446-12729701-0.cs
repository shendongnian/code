    public class CategoricalDataPointCodeDomSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
        {
            CodeStatementCollection collection = codeObject as CodeStatementCollection;
            if (collection != null)
            {
                foreach (CodeStatement statement in collection)
                {
                    CodeAssignStatement codeAssignment = statement as CodeAssignStatement;
                    if (codeAssignment != null)
                    {
                        CodePropertyReferenceExpression properyRef = codeAssignment.Left as CodePropertyReferenceExpression;
                        CodePrimitiveExpression primitiveExpression = codeAssignment.Right as CodePrimitiveExpression;
                        if (properyRef != null && properyRef.PropertyName == "Value" && primitiveExpression != null && primitiveExpression.Value != null)
                        {
                            primitiveExpression.Value = Convert.ToDouble(primitiveExpression.Value);
                            break;
                        }
                    }
                }
            }
            return base.Deserialize(manager, codeObject);
        }
    }
