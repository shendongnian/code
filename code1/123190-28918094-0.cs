            // Declare the ID Property.
            CodeMemberProperty IDProperty = new CodeMemberProperty();
            IDProperty.Attributes = MemberAttributes.Public;
            IDProperty.Name = "Id";
            IDProperty.HasGet = true;
            IDProperty.HasSet = true;
            IDProperty.Type = new CodeTypeReference(typeof(System.Int16));
            IDProperty.Comments.Add(new CodeCommentStatement(
            "Id is identity"));
            targetClass.Members.Add(IDProperty);
