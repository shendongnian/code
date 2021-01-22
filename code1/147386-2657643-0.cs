    CodeTypeDeclaration type = new CodeTypeDeclaration("BugTracker");
    type.IsEnum = true;
    foreach (var valueName in new string[] { "Bugzilla", "Redmine" })
    {
      // Creates the enum member
      CodeMemberField f = new CodeMemberField("BugTracker", valueName);
      // Adds the description attribute
      f.CustomAttributes.Add(new CodeAttributeDeclaration("Description", new CodeAttributeArgument(new CodePrimitiveExpression(valueName))));
      type.Members.Add(f);
    }
