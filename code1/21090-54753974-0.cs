      provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
      var literal = writer.ToString();
      var r2 = new Regex(@"\"" \+.\n[\s]+\""", RegexOptions.ECMAScript);
      literal = r2.Replace(literal, "");
      return literal;
 
