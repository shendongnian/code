    [Serializer(typeof(MySerializer))]
    class MyControl : Control {}
    
    class MySerializer : CodeDomSerializer
    {
        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
          CodeDomSerializer baseSerializer;
          CodeStatementCollection statements;
          CodeExpression targetObject;
    
          if(manager == null || value == null)
          {
            return null;
          }
    
          baseSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(MyControl).BaseType, typeof(CodeDomSerializer));
          statements = baseSerializer.Serialize(manager, value) as CodeStatementCollection;
          if(statements == null)
          {
            statements = new CodeStatementCollection();
          }
    
          targetObject = GetExpression(manager, value);
          if(targetObject != null)
          {
            // add 'myControl.Visible = true;' statement.
            statements.Add(
              new CodeAssignStatement(
                new CodeFieldReferenceExpression(targetObject, "Visible"),
                new CodePrimitiveExpression(true)));
          }
          return statements;
        }
    }
