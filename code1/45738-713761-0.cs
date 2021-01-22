    Int32[] ints = INTARR();
    CodeExpression[] intExps = new CodePrimitiveExpression[ints.Length];
    for (int i = 0; i < ints.Length; i++)
       intExps[i] = new CodePrimitiveExpression(ints[i]);
    CodeVariableDeclarationStatement cvds = new CodeVariableDeclarationStatement(
       "Int32[]", "x", new CodeArrayCreateExpression("Int32", intExps));
