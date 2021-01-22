    public class MyExtension
    {
        IXPathNavigable context;
        public MyExtension( IXPathNavigable context )
        {
            this.context = context;
        }
        public object Evaluate( string expression )
        {
            return context.Evaluate( expression );
        }
    }
    XsltArgumentList args = new XsltArgumentList();
    args.AddExtensionObject("my-ext", new MyExtension(doc));
    xslt.Transform( doc, args output );
