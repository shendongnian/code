        CodeTypeDeclaration newType = new CodeTypeDeclaration("TestType");
        CodeSnippetTypeMember snippet = new CodeSnippetTypeMember();
        snippet.Comments.Add(new CodeCommentStatement("this is integer property", true));
        snippet.Text="public int IntergerProperty { get; set; }";
        newType.Members.Add(snippet);
    
