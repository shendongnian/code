    [PSerializable]
    [MulticastAttributeUsage(PersistMetaData = true, AllowExternalAssemblies = false)]
    [LinesOfCodeAvoided(50)]
    // We need to implement IInstanceScopedAspect to introduce and import members
    public sealed class CatalogueLazyLoad : LocationInterceptionAspect, IInstanceScopedAspect
    {
        public string Name { get; set; }
        public string Charset { get; set; }
        public CacheType Cache { get; set; }
        // Introduce a new property into the target class (only once)
        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public HashSet<string> LoadedCharsets { get; set; }
        // Import the introduced property (it may be introduced by this aspect or another aspect on another property)
        [ImportMember("LoadedCharsets", IsRequired = true, Order = ImportMemberOrder.AfterIntroductions)]
        public Property<HashSet<string>> LoadedCharsetsProperty;
        public CatalogueLazyLoad(string name, string charset)
        {
            Name = name;
            Charset = charset;
            Cache = CacheType.CACHED;
        }
        private void GetValue(LocationInterceptionArgs args, bool propagate = false)
        {
            var properties = args.Instance.GetType().GetProperties();
            // JSONObject is just an object with string KEY and string VALUE, you can add dummy data here using a Dictionary<string, string>
            IEnumerable<JSONObject> result = API.Methods.GetCharsetData(id, Charset).Result;
            if (result.Count() > 0)
            {
                foreach (PropertyInfo propertyInfo in properties)
                {
                    CatalogueLazyLoad attribute = propertyInfo.GetCustomAttribute<CatalogueLazyLoad>();
                    if (attribute != null && attribute.Charset == Charset)
                    {
                        propertyInfo.SetValue(args.Instance,
                                              Convert.ChangeType(result.Where(x => x.Key == attribute.Name).Select(x => x.Value).FirstOrDefault(), propertyInfo.PropertyType, CultureInfo.CurrentCulture),
                                              null);
                    }
                }
                if (propagate)
                {
                    this.LoadedCharsetsProperty.Get().Add(this.Charset);
                }
                args.ProceedGetValue();
            }
        }
        public override sealed void OnGetValue(LocationInterceptionArgs args)
        {
            base.OnGetValue(args);
            switch (Cache)
            {
                case CacheType.CACHED:
                    bool loaded = this.LoadedCharsetsProperty.Get().Contains(this.Charset);
                    if (!loaded)
                    {
                        GetValue(args, true);
                    }
                    break;
                case CacheType.FORCE_NO_CACHE:
                    GetValue(args);
                    break;
                default:
                    break;
            }
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
            this.LoadedCharsetsProperty.Set(new HashSet<string>());
        }
    }
