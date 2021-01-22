using System;
using System.Linq;
public static IEnumerable&lt;Type&gt; GetAllInterfacesForType(this Type type)
{
   foreach (var interfaceType in type.GetInterfaces())
   {
       yield return interfaceType;
       foreach (var t in interfaceType.GetAllInterfacesForType())
           yield return t;
   }
}
public static IEnumerable&lt;Type&gt; GetUniqueInterfacesForType(this Type type)
{ return type.GetAllInterfaces().Distinct(); }
