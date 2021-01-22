    public class InlinesResolver {
      private object _target;
      public InlinesResolver(object target) {
        _target = target;
      }
      public bool HasInlines {
        get {
          return ResolveAttribute() != null;
        }
      }
      public InlineCollection Inlines {
        get {
          var propertyName = ResolveAttribute().Name;
          return (InlineCollection)
            _target.GetType().GetProperty(propertyName).GetGetMethod().Invoke(_target, new object[] { });
        }
      }
      private ContentPropertyAttribute ResolveAttribute() {
        var attrs = _target.GetType().GetCustomAttributes(typeof(ContentPropertyAttribute), true);
        if (attrs.Length == 0) return null;
        return (ContentPropertyAttribute)attrs[0];
      }
    }
