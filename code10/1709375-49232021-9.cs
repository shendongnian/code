    public void AddFields()
    {
        // Declare the widthValue field.
        CodeMemberField widthValueField = new CodeMemberField();
        widthValueField.Attributes = MemberAttributes.Private;
        widthValueField.Name = "widthValue";
        widthValueField.Type = new CodeTypeReference(typeof(System.Double));
        widthValueField.Comments.Add(new CodeCommentStatement(
            "The width of the object."));
        targetClass.Members.Add(widthValueField);
    
        // Declare the heightValue field
        CodeMemberField heightValueField = new CodeMemberField();
        heightValueField.Attributes = MemberAttributes.Private;
        heightValueField.Name = "heightValue";
        heightValueField.Type =
            new CodeTypeReference(typeof(System.Double));
        heightValueField.Comments.Add(new CodeCommentStatement(
            "The height of the object."));
        targetClass.Members.Add(heightValueField);
    }
