    var updated = classDeclaration.WithBaseList(
        classDeclaration.BaseList.WithTypes(
            classDeclaration.BaseList.Types.Insert(
                0,
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseName("Repository<User, UserTable>")))));
