    public class SelectiveValueEqualityReferenceResolver : EquivalencingReferenceResolver
    {
          private readonly Dictionary<Type, Dictionary<object, object>> _representatives;
          public SelectiveValueEqualityReferenceResolver(IReferenceResolver defaultResolver)
              : base(defaultResolver)
          {
              this._representatives = new Dictionary<Type, Dictionary<object, object>>();
          }
          protected override bool TryGetRepresentativeObject(object obj, out object representative)
          {
              var type = obj.GetType();
              if (type.GetTypeInfo().IsClass && this._representatives.TryGetValue(type, out var typedItems))
                  return typedItems.TryGetValue(obj, out representative);
              return base.TryGetRepresentativeObject(obj, out representative);
          }
          protected override object GetOrAddRepresentativeObject(object obj)
          {
              var type = obj.GetType();
              if (!type.GetTypeInfo().IsClass)
                  return base.GetOrAddRepresentativeObject(obj);
              if (!this._representatives.TryGetValue(type, out var typedItems))
              {
                  typedItems = new Dictionary<object, object>();
                  this._representatives.Add(type, typedItems);
              }
              if (!typedItems.TryGetValue(obj, out var representative))
                  representative = typedItems[obj] = obj;
              return representative;
          }
    }
