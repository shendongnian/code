    var class1 = new System.CodeDom.CodeTypeDeclaration(className);
    class1.IsClass=true;
    class1.TypeAttributes = System.Reflection.TypeAttributes.Public;
    class1.Comments.Add(new System.CodeDom.CodeCommentStatement("This class has been programmatically generated"));
    // add a constructor to the class
    var ctor= new System.CodeDom.CodeConstructor();
    ctor.Attributes = System.CodeDom.MemberAttributes.Public;
    ctor.Comments.Add(new System.CodeDom.CodeCommentStatement("the null constructor"));
    class1.Members.Add(ctor);
      
    // add one statement to the ctor:  an assignment
    // in code it will look like;  _privateField = new Foo(); 
    ctor.Statements.Add(new System.CodeDom.CodeAssignStatement(new System.CodeDom.CodeVariableReferenceExpression("_privateField"), new System.CodeDom.CodeObjectCreateExpression(fooType)));
      
    // include a private field into the class
    System.CodeDom.CodeMemberField field1;
    field1= new System.CodeDom.CodeMemberField();
    field1.Attributes = System.CodeDom.MemberAttributes.Private;
    field1.Name= "_privateField";
    field1.Type=new System.CodeDom.CodeTypeReference(fooType);
    class1.Members.Add(field1);
