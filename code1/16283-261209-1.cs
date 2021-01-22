    using System;
    using System.Reflection;
    using PostSharp.Laos;
    
    namespace IteratorBlocks
    {
        [Serializable]
        class NullArgumentAspect : OnMethodBoundaryAspect
        {
            string name;
            int position;
    
            public NullArgumentAspect(string name)
            {
                this.name = name;
            }
    
            public override void CompileTimeInitialize(MethodBase method)
            {
                base.CompileTimeInitialize(method);
                ParameterInfo[] parameters = method.GetParameters();
                for (int index = 0; index < parameters.Length; index++)
                {
                    if (parameters[index].Name == name)
                    {
                        position = index;
                        return;
                    }
                }
                throw new ArgumentException("No parameter with name " + name);
            }
    
            public override void OnEntry(MethodExecutionEventArgs eventArgs)
            {
                if (eventArgs.GetArguments()[position] == null)
                {
                    throw new ArgumentNullException(name);
                }
            }
        }
    }
