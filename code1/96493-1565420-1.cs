    void Foo<T>(T arg)
    {
      if (arg is IElement)
      {
        var argAsIElement = arg as IElement;
        // Do something with argAsIElement
      }
      if (arg is HtmlControl)
      {
        var argAsHtmlControl = arg as HtmlControl;
        // Do something with argAsHtmlControl
      }
    }
