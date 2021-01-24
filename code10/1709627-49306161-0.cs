    [PSerializable]
    public class ProfileProviderAttribute : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            MethodBase targetMethod = (MethodBase) targetElement;
            foreach (var codeReference in ReflectionSearch.GetDeclarationsUsedByMethod(targetMethod))
            {
                if (codeReference.UsedDeclaration.MemberType == MemberTypes.Method)
                {
                    yield return new AspectInstance(codeReference.UsedDeclaration, new ProfileAttribute());
                }
            }
        }
    }
