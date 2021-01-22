    Microsoft.CodeAnalysis.CSharp.SyntaxFacts.IsReservedKeyword(
            Microsoft.CodeAnalysis.CSharp.SyntaxFacts.GetKeywordKind("protected")
    );
    foreach (ColumnDefinition cl in tableColumns)
    {
        sb.Append(@"         public ");
        sb.Append(cl.DOTNET_TYPE);
        sb.Append(" ");
    
        // for keywords
        //if (!Microsoft.CodeAnalysis.CSharp.SyntaxFacts.IsValidIdentifier(cl.COLUMN_NAME))
        if (Microsoft.CodeAnalysis.CSharp.SyntaxFacts.IsReservedKeyword(
            Microsoft.CodeAnalysis.CSharp.SyntaxFacts.GetKeywordKind(cl.COLUMN_NAME)
            ))
            sb.Append("@");
    
        sb.Append(cl.COLUMN_NAME);
        sb.Append("; // ");
        sb.AppendLine(cl.SQL_TYPE);
    } // Next cl 
