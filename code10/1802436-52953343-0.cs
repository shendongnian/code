    using Microsoft.Linq.Translations;
    
    // (...) namespace, class, etc
    
    private static readonly CompiledExpression<MyClass, List<string>> _myExpression = DefaultTranslationOf<MyClass>
    	.Property(x => x.MyProperty)
    	.Is(x => new List<string>());
    
    [NotMapped]
    public List<string> MyProperty
    {
    	get { return _myExpression.Evaluate(this); }
    }
