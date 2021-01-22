            // Get the handle for the RuntimeMethodInfo type
            var corlib = Assembly.GetAssembly(typeof (MethodInfo));
            var corlibTypes = corlib.GetModules().SelectMany(mod => mod.FindTypes((a, b) => true, null));
            Type rtmiType = corlibTypes.Where(t => t != null && t.FullName != null && t.FullName.Contains("Reflection.RuntimeMethodInfo")).First();
            // Find the extension method
            var methods = typeof (Html).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var methodInfo in methods)
            {
                if (methodInfo.Name == "TextBoxFor")
                {
                    // Try to monkeypatch this to be private instead of public
                    var methodAttributes = rtmiType.GetField("m_methodAttributes", BindingFlags.NonPublic | BindingFlags.Instance);
                    if(methodAttributes != null)
                    {
                        var attr = methodAttributes.GetValue(methodInfo);
                        attr = ((MethodAttributes)attr) | MethodAttributes.Private;
                        methodAttributes.SetValue(methodInfo, attr);                
                    }
                }
            }
