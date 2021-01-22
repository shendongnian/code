using System;
using System.Linq;
public static IEnumerable&gt;Type&lt; GetAllInterfacesForType(this Type type)
{
   foreach (var interfaceType in type.GetInterfaces())
   {
       yield return interfaceType;
       foreach (var t in interfaceType.GetAllInterfacesForType())
           yield return t;
   }
}
public static IEnumerable&gt;Type&lt; GetUniqueInterfacesForType(this Type type)
{ return type.GetAllInterfaces().Distinct(); }
