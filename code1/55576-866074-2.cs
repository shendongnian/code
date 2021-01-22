    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class InlineConverterExtension : MarkupExtension
    {
      static Dictionary<string, WeakReference> s_WeakReferenceLookup;
      
      Type m_ConverterType;
      object[] m_Arguments;
    
      static InlineConverterExtension()
      {
        s_WeakReferenceLookup = new Dictionary<string, WeakReference>();
      }
    
      public InlineConverterExtension()
      {
      }
    
      public InlineConverterExtension(Type converterType)
      {
        m_ConverterType = converterType;
      }
    
      /// <summary>
      /// The type of the converter to create
      /// </summary>
      /// <value>The type of the converter.</value>
      public Type ConverterType
      {
        get { return m_ConverterType; }
        set { m_ConverterType = value; }
      }
    
      /// <summary>
      /// The optional arguments for the converter's constructor.
      /// </summary>
      /// <value>The argumments.</value>
      public object[] Arguments
      {
        get { return m_Arguments; }
        set { m_Arguments = value; }
      }
    
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
        IProvideValueTarget target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
    
        PropertyInfo propertyInfo = target.TargetProperty as PropertyInfo;
    
        if (!propertyInfo.PropertyType.IsAssignableFrom(typeof(IValueConverter)))
          throw new NotSupportedException("Property '" + propertyInfo.Name + "' is not assignable from IValueConverter.");
    
        System.Diagnostics.Debug.Assert(m_ConverterType != null, "ConverterType is has not been set, ConverterType{x:Type converterType}");
    
        try
        {
          string key = m_ConverterType.ToString();
    
          if (m_Arguments != null)
          {
            List<string> args = new List<string>();
            foreach (object obj in m_Arguments)
              args.Add(obj.ToString());
    
            key = String.Concat(key, "_", String.Join("|", args.ToArray()));
          }
    
          WeakReference wr = null;
          if (s_WeakReferenceLookup.TryGetValue(key, out wr))
          {
            if (wr.IsAlive)
              return wr.Target;
            else
              s_WeakReferenceLookup.Remove(key);
          }
    
          object converter = (m_Arguments == null) ? Activator.CreateInstance(m_ConverterType) : Activator.CreateInstance(m_ConverterType, m_Arguments);
          s_WeakReferenceLookup.Add(key, new WeakReference(converter));
    
          return converter;
        }
        catch(MissingMethodException)
        {
          // constructor for the converter does not exist!
          throw;
        }
      }
    
    }
