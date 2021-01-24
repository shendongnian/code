    public class ColorHandler
    {
       static ColorHandler() 
       {
          CurrentColors = new List<KeyValuePair<string,int>>();
       }
       private static List<KeyValuePair<string,int>> _current;
       public static List<KeyValuePair<string,int>> CurrentColors 
       { 
         get
         {
            return _current;
         }
         set
         {
             if(value != _current && (null != _colorType))
             {
                _current = Value;
                _colorType = DefineColor();
             }
         }
       } 
       private static Type _colorType;
       public static Type ColorType => _colorType ?? (_colorType = DefineColor());
       private static DefineColor()
       {
           var arbitraryName = new AssemblyName(Guid.NewGuid().Replace("-", string.Empty));
           var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(arbitraryName, AssemblyBuilderAccess.Run);
           var builder = assemblyBuilder.DefineDynamicModule(arbitraryName.Name);
           var colorEnum = builder.DefineEnum("Color", TypeAttributes.Public, typeof(int));
           foreach(var color in CurrentColors)
           {
               colorEnum.DefineLiteral(color.Key,color.Value);
           }
           return colorEnum.CreateType();
       }
       public static object HandleEnumViaReflection(object e)
       {
          var openType = typeof(ColorConsumer<>);
          var typeToActivate = openType.MakeGenericType(new Type[]{ ColorType });
          var consumer = Activator.CreateInstance(typeToActivate, new object[]{ e });
          return consumer.HandleEnum();
       }
    }
