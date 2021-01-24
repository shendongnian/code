    // Roughly equivalent to:
    // PXSelect<TDacObject, Where<TDacObject.TDacField, Equals<Required<fieldParamValue>>>>
    
    // TDacobject below is extracted from the type 'fieldType.DeclaringType'
    // You can substitute that for your generic DAC Type entity
    public static List<T> SelectById<T, TField>(this PXGraph graph, object id)
        where TField : class, IBqlField
        where T : class, IBqlTable
    {
        return SelectById(graph, typeof(TField), id).Cast<T>().ToList();
    }
    
    public static List<object> SelectById(this PXGraph graph, Type fieldType, object id)
    {
    	var select = CreateSelectCommand(fieldType);
    	var view = GetView(graph, fieldType, select);
    
    	return view.SelectMulti(id);
    }
    
    public static BqlCommand CreateSelectCommand(Type fieldType)
    {
        return CreateSelectCommand(fieldType.DeclaringType, fieldType);
    }
    
    public static BqlCommand CreateSelectCommand(Type entityType, Type fieldType)
    {
        Type required = BqlCommand.Compose(typeof(Required<>), fieldType);
        Type equal = BqlCommand.Compose(typeof(Equal<>), required);
        Type where = BqlCommand.Compose(typeof(Where<,>), fieldType, equal);
    
        return BqlCommand.CreateInstance(typeof(Select<,>), entityType, where);
    }
    
    public static PXView GetView(this PXGraph graph, Type fieldType, BqlCommand select)
    {
        PXView view;
        graph.Views.TryGetValue(fieldType.FullName, out view);
    
        if (view == null)
        {
            view = new PXView(graph, false, @select);
            graph.Views.Add(fieldType.FullName, view);
            graph.EnsureCachePersistence(fieldType.DeclaringType);
        }
    
        return view;
    }
