    [AttributeUsage(AttributeTargets.Parameter)]
    public class HTMLEncodeAttribute : Attribute, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            ParameterInfo parameter = (ParameterInfo)targetElement;
            IAspectRepositoryService aspectRepositoryService = PostSharpEnvironment.CurrentProject.GetService<IAspectRepositoryService>();
            if (!aspectRepositoryService.HasAspect(parameter.Member, typeof(HTMLEncodeImplAspect)))
            {
                yield return new AspectInstance(parameter.Member, new HTMLEncodeImplAspect());
            }
        }
    }
    [PSerializable]
    public class HTMLEncodeImplAspect : MethodInterceptionAspect
    {
        private List<int> encodedParams;
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            this.encodedParams = new List<int>();
            ParameterInfo[] allParams = method.GetParameters();
            for (int i = 0; i < allParams.Length; i++)
            {
                if (allParams[i].GetCustomAttribute(typeof(HTMLEncodeAttribute)) != null)
                {
                    this.encodedParams.Add(i);
                }
            }
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            foreach (int p in this.encodedParams)
            {
                args.Arguments.SetArgument(p, "encoded value");
            }
            args.Proceed();
        }
    }
