        public static Assembly LoadAssembly(string assembly, Evidence evidence)
        {
            Assembly asm;
            MethodInfo load = 
                typeof(Assembly).GetMethod("Load", 
                                            new Type[] {typeof(string), typeof(Evidence)});
            if (Attribute.IsDefined(load, typeof(ObsoleteAttribute)))
            {
                asm = Assembly.Load(assembly);
            }
            else
            {
                asm = Assembly.Load(assembly, evidence);
            }
            return asm;
        }
