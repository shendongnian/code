    namespace Elements
    {
      class Program
      {
         static void Main(string[] args)
         {
            System.Xml.Linq.XElement sample = System.Xml.Linq.XElement.Parse(
               "<Element a=\"3\" b=\"Havarti\" modeSel=\"Complex\" />");
            Element c1 = Element.ParseXml(sample);
         }
      }
      public class ModeSelection
      {
         private int mode;
         public static explicit operator ModeSelection(string value)
         {
            ModeSelection result = new ModeSelection();
            if (String.Compare(value, "Simple", true) == 0)
               result.mode = 1;
            else if (String.Compare(value, "Complex", true) == 0)
               result.mode = 2;
            else if (!int.TryParse(value, out result.mode))
               throw new FormatException("Cannot convert value to type " + result.GetType().Name);
            return result;
         }
         string Description
         {
            get
            {
               switch (mode)
               {
                  case 1:
                     return "Simple";
                  case 2:
                     return "Complex";
                  default:
                     return "Other";
               }
            }  
         }
      }
      public abstract class BaseElement<T> where T : BaseElement<T>, new()
      {
         public static T ParseXml(System.Xml.Linq.XElement element)
         {
            var e = (T)Activator.CreateInstance(Type.GetType("Elements." + element.Name));
            Type[] convParamTypes = new Type[] {typeof(string)};
            foreach (var attr in element.Attributes())
            {
               var property = e.GetType().GetProperty(attr.Name.LocalName);
               System.Reflection.MethodInfo conv = property.PropertyType.GetMethod(
                  "op_Explicit", convParamTypes);
               if (conv != null)
                  property.SetValue(e, conv.Invoke(null, new object[] {attr.Value}), null);
               else
                  property.SetValue(e, Convert.ChangeType(attr.Value, property.PropertyType), null);
            }
            foreach (var x in element.Elements())
               e.Elements.Add(ParseXml(x));
            return e;
         }
         public BaseElement()
         {
            Elements = new List<T>();
         }
         public IList<T> Elements
         {
            get;
            set;
         }
      }
      public class Element : BaseElement<Element>
      {
         int _a;
         string _b;
         ModeSelection _modeSel;
         public int a
         {
            get
            {
               return _a;
            }
            set
            {
               _a = value;
            }
         }
         public string b
         {
            get
            {
               return _b;
            }
            set
            {
               _b = value;
            }
         }
         public ModeSelection modeSel
         {
            get
            {
               return _modeSel;
            }
            set
            {
               _modeSel = value;
            }
         }
      }
    }
