            string definedIn = typeof(XmlDecoderAttribute).Assembly.GetName().Name;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                // Note that we have to call GetName().Name.  Just GetName() will not work.  The following
                // if statement never ran when I tried to compare the results of GetName().
                if ((!assembly.GlobalAssemblyCache) && ((assembly.GetName().Name == definedIn) || assembly.GetReferencedAssemblies().Any(a => a.Name == definedIn)))
                    foreach (Type type in assembly.GetTypes())
                        if (type.GetCustomAttributes(typeof(XmlDecoderAttribute), true).Length > 0)
