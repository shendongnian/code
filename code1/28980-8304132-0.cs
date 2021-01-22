    foreach(System.Reflection.AssemblyName an in System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies()){						
    			System.Reflection.Assembly asm = System.Reflection.Assembly.Load(an.ToString());
    			foreach(Type type in asm.GetTypes()){	
    				//PROPERTIES
    				foreach (System.Reflection.PropertyInfo property in type.GetProperties()){
    					if (property.CanRead){
    						Response.Write("<br>" + an.ToString() + "." + type.ToString() + "." + property.Name);		
    					}
    				}
    				//METHODS
    				var methods = type.GetMethods();
    				foreach (System.Reflection.MethodInfo method in methods){				
    					Response.Write("<br><b>" + an.ToString() + "."  + type.ToString() + "." + method.Name  + "</b>");	
    					foreach (System.Reflection.ParameterInfo param in method.GetParameters())
    					{
    					    Response.Write("<br><i>Param=" + param.Name.ToString());
    					    Response.Write("<br>  Type=" + param.ParameterType.ToString());
    					    Response.Write("<br>  Position=" + param.Position.ToString());
    					    Response.Write("<br>  Optional=" + param.IsOptional.ToString() + "</i>");
    					}
    				}
    			}
    		}
