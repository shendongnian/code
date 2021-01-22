    System.Type mt= a[0].GetType();
    System.CodeDom.CodeTypeDeclaration class1 = new System.CodeDom.CodeTypeDeclaration(mt.Name);
    class1.IsClass=true;
    class1.TypeAttributes = System.Reflection.TypeAttributes.Public;
    class1.Comments.Add(new System.CodeDom.CodeCommentStatement("Wrapper class for " + mt.Name));
    System.CodeDom.CodeConstructor ctor;
    ctor= new System.CodeDom.CodeConstructor();
    ctor.Attributes = System.CodeDom.MemberAttributes.Public;
    ctor.Comments.Add(new System.CodeDom.CodeCommentStatement("the null constructor"));
    class1.Members.Add(ctor);
    ctor.Statements.Add(new System.CodeDom.CodeAssignStatement(new System.CodeDom.CodeVariableReferenceExpression("m_wrapped"), new System.CodeDom.CodeObjectCreateExpression(mt)));
    ctor= new System.CodeDom.CodeConstructor();
    ctor.Attributes = System.CodeDom.MemberAttributes.Public;
    ctor.Comments.Add(new System.CodeDom.CodeCommentStatement("the 'copy' constructor"));
    class1.Members.Add(ctor);
    ctor.Parameters.Add(new System.CodeDom.CodeParameterDeclarationExpression(mt,"X"));
    ctor.Statements.Add(new System.CodeDom.CodeAssignStatement(new System.CodeDom.CodeVariableReferenceExpression("m_wrapped"), new System.CodeDom.CodeVariableReferenceExpression("X")));
    // embed a local (private) copy of the wrapped type
    System.CodeDom.CodeMemberField field1;
    field1= new System.CodeDom.CodeMemberField();
    field1.Attributes = System.CodeDom.MemberAttributes.Private;
    field1.Name= "m_wrapped";
    field1.Type=new System.CodeDom.CodeTypeReference(mt);
    class1.Members.Add(field1);
    ...
