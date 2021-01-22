    public static List<DependencyProperty> GetAttachedProperties(Object element)
        {
            List<DependencyProperty> attachedProperties = new List<DependencyProperty>();
            foreach (AssemblyPart ap in Deployment.Current.Parts)
            {
                StreamResourceInfo sri = Application.GetResourceStream(new Uri(ap.Source, UriKind.Relative));
                Assembly a = new AssemblyPart().Load(sri.Stream);
                GetAttachedProperties(a, attachedProperties);
            }
            return attachedProperties;
        }
	    private static void GetAttachedProperties(Assembly a, List<DependencyProperty> attachedProperties)
	    {
	        foreach (var type in a.GetTypes())
	        {
	            Debug.WriteLine(type.FullName);
	            var dependencyProperties = type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(
	                f => typeof (DependencyProperty).IsAssignableFrom(f.FieldType)).Select(f => f);
	            foreach (var dp in dependencyProperties)
	            {
	                FieldInfo info = dp;
                    var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
                    Debug.WriteLine("{0} suitable dp methods found", methods.Count());
	                var fields = methods.Where(
	                    m => (IsAttachedGetter(m, info) || IsAttachedSetter(m, info))).Select(
	                    m => info).ToArray();
                    foreach(var field in fields)
                    {
                        try
                        {
                            Debug.WriteLine("Adding dependency property {0} from type {1}", dp.Name, type.FullName);
                            attachedProperties.Add((DependencyProperty)field.GetValue(null));
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Error getting dependency property {0} from type {1}, exception: {2}",
                                dp.Name, type.FullName, e);
                        }
                    }
	            }
	        }
	    }
	    private static bool IsAttachedSetter(MethodInfo methodInfo, FieldInfo info)
	    {
            string setName = string.Format("Set{0}", info.Name.Replace("Property", string.Empty));
            if(methodInfo.Name == setName)
            {
                var methodParams = methodInfo.GetParameters();
                return methodParams.Count() == 2
                       && typeof (DependencyObject).IsAssignableFrom(methodParams[0].ParameterType);
            }
	        return false;
	    }
	    private static bool IsAttachedGetter(MethodInfo methodInfo, FieldInfo info)
	    {
            string getName = string.Format("Get{0}", info.Name.Replace("Property", string.Empty));
            if(methodInfo.Name == getName)
            {
                var methodParams = methodInfo.GetParameters();
                return methodParams.Count() == 1 &&
                       methodParams[0].ParameterType.IsAssignableFrom(typeof (DependencyObject));
            }
	        return false;
	    }
