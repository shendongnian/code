      CodeArrayCreateExpression CodeArrayCreateExpression(Array array)
      {
         CodeArrayCreateExpression arrayCreateExpression = new CodeArrayCreateExpression(array.GetType(), array.GetLength(0));
         if (array.GetType().GetElementType().IsArray)
         {
            CodeArrayCreateExpression[] values = new CodeArrayCreateExpression[array.GetLength(0)];
            for (int j = 0; j < array.GetLength(0); j++)
            {
               values[j] = this.CodeArrayCreateExpression((Array)array.GetValue(j));
            }
            arrayCreateExpression.Initializers.AddRange(values);
         }
         else if(array.GetType().GetElementType().IsPrimitive)
         {
            CodeCastExpression[] values = new CodeCastExpression[array.GetLength(0)];
            for (int j = 0; j < values.Length; j++)
            {
               values[j] = new CodeCastExpression();
               values[j].Expression = new CodePrimitiveExpression(array.GetValue(j));
               values[j].TargetType = new CodeTypeReference(array.GetType().GetElementType());
            }
            arrayCreateExpression.Initializers.AddRange(values);
         }
         return arrayCreateExpression;
      }
