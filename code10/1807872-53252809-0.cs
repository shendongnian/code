    using System.CodeDom;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    public class MyCollectionSerializer : CodeDomSerializer
    {
        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            var baseSerializer = (CodeDomSerializer)manager.GetSerializer(
                typeof(MyCollection).BaseType, typeof(CodeDomSerializer));
            var statements = (CodeStatementCollection)baseSerializer.Serialize(manager, value);
            var property = TypeDescriptor.GetProperties(value)[nameof(MyCollection.MyString)];
            var targetObject = base.GetExpression(manager, value);
            var cpre = new CodePropertyReferenceExpression(targetObject, property.Name);
            var cpe = new CodePrimitiveExpression(property.GetValue(value));
            var cas = new CodeAssignStatement(cpre, cpe);
            statements.Add(cas);
            return statements;
        }
    } 
