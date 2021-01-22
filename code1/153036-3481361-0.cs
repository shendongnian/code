        	internal class StaticMembersDynamicWrapper : DynamicObject
        		{
        			private readonly IDictionary<String, MemberInfo> staticMembers = new Dictionary<string, MemberInfo>();
        			private readonly Type type;
        
        			public StaticMembersDynamicWrapper(Type type)
        			{
        				this.type = type;
        				type.GetMembers(BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public)
        					.Each(member => staticMembers[member.Name] = member);
        			}
        
        			public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        			{
        				var name = indexes[0] as string;
        
        				MemberInfo member;
        
        				if (false == staticMembers.TryGetValue(name, out member))
        				{
        					result = null;
        					return false;
        				}
        
        				var prop = member as PropertyInfo;
        				if (prop != null)
        				{
        					result = prop.GetValue(null, null);
        					return true;
        				}
        				var method = member as MethodInfo;
        				if (method != null)
        				{
        					var parameterTypes = (from p in method.GetParameters()
        					                      select p.ParameterType).ToArray();
        					var delegateType = method.ReturnType != typeof (void)
        					            	? Expression.GetFuncType(parameterTypes.Union(new[]{method.ReturnType}).ToArray())
        					            	: Expression.GetActionType(parameterTypes);
        					result = Delegate.CreateDelegate(delegateType, method);
        					return true;
        				}
        				result = null;
        				return false;
        			}
        }
    dynamic d = new StaticMembersDynamicWrapper(typeof(string));
    var result = d["IsNullOrEmpty"](String.Empty);
