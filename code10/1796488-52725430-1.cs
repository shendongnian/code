    public virtual bool ShouldHandle(ExceptionHandlerContext context)
    {
      if (context == null)
        throw new ArgumentNullException(nameof (context));
      return context.ExceptionContext.CatchBlock.IsTopLevel;
    }
