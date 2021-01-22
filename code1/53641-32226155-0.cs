    public static bool IsDesignerContext()
    {
      var maybeExpressionUseLayoutRounding =
        Application.Current.Resources["ExpressionUseLayoutRounding"] as bool?;
      return maybeExpressionUseLayoutRounding ?? false;
    }
