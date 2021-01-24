    [PSerializable]
    public class NotifyDataErrorInfoAttribute : LocationLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type propertyType = ((LocationInfo)targetElement).LocationType;
            Type aspectType = typeof(NotifyDataErrorInfoAspectImpl<>).MakeGenericType(propertyType);
            yield return new AspectInstance(
                targetElement, (IAspect) Activator.CreateInstance(aspectType));
        }
    }
    [PSerializable]
    public class NotifyDataErrorInfoAspectImpl<T> : ILocationInterceptionAspect,
                                                    IInstanceScopedAspect,
                                                    IAdviceProvider
    {
        public Func<T, IList<DataErrorInfo>> ValidateDelegate;
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            LocationInfo property = (LocationInfo)targetElement;
            string validateMethodName = "Validate" + property.Name;
            yield return new ImportMethodAdviceInstance(
                typeof(NotifyDataErrorInfoAspectImpl<>).GetField("ValidateDelegate"),
                validateMethodName,
                true);
        }
        public void OnSetValue(LocationInterceptionArgs args)
        {
            if (ValidateDelegate((T) args.Value)?.Any() == true)
                throw new ArgumentException("...");
            args.ProceedSetValue();
        }
        public void OnGetValue(LocationInterceptionArgs args)
        {
            args.ProceedGetValue();
        }
        public void RuntimeInitialize(LocationInfo locationInfo)
        {
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
