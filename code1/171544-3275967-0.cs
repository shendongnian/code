    //public HtmlHelper Html { get; protected set; } // line 42
    public HtmlHelper<TModel> Html { get; protected set; }
    
    //Html = new HtmlHelper( viewContext, this ); // line 37
    Html = new HtmlHelper<TModel>( viewContext, this );
