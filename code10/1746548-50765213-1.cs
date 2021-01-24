    public class Mapping
    {
        [DataMember]
        public long Id { get; set; }
    }
    [DataContract]
    public class ProductDTO: Mapping
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortDescription{ get; set; }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(t => t.Name, opt => opt.ResolveUsing<LocalizationResolver, EntityInfo>(src => new EntityInfo()
                {
                    LocaleKeyGroup = "Product",
                    LocaleKey = "Name",
                    DefaultValue  = src.Name
                }))
                .ForMember(t => t.ShortDescription, opt => opt.ResolveUsing<LocalizationResolver, EntityInfo> (src => new EntityInfo()
                {
                    LocaleKeyGroup = "Product",
                    LocaleKey = "ShortDescription",
                    DefaultValue = src.ShortDescription
                }));
        }
    }
    public class EntityInfo
    {
        public string LocaleKeyGroup { get; set; }
        public string LocaleKey { get; set; }
        public string DefaultValue { get; set; }
    }
    public class LocalizationResolver : IMemberValueResolver<Mapping, object, EntityInfo, string>
    {
        public string Resolve(Mapping source, object destination, EntityInfo sourceMember, string destMember,
            ResolutionContext context)
        {
            
            context.Items.TryGetValue("Language", out object languageObject);
            context.Items.TryGetValue("Repository", out object repositoryObject);
            ILocalizedPropertyRepository repository = repositoryObject as ILocalizedPropertyRepository;
            LanguageDTO language = languageObject as LanguageDTO;
            if (language == null || repository == null)
            {
                throw new ArgumentNullException($"Language and LocalizationRepository as AutoMapper Parameter");
            }      
            if(source.Id == 0)
            {
                return sourceMember.DefaultValue;
            }
            //Get the value from the DB
            return LocalizationExtension.GetLocalized(sourceMember.LocaleKey, sourceMember.LocaleKeyGroup, sourceMember.DefaultValue, source.Id, language, repository);
        }
    }
    public static class LocalizationExtension
    {
        public static string GetLocalized(string localeKey, string localeKeyGroup, string defaultValue, long entityId, LanguageDTO language, ILocalizedPropertyRepository localizedPropertyRepository)
        {
            var resultStr = String.Empty;
            if (language != null)
            {
                resultStr = localizedPropertyRepository.GetLocalizedValue(language, entityId, localeKeyGroup, localeKey);
            }
            if (string.IsNullOrEmpty(resultStr))
            {
                resultStr = defaultValue;
            }
            return resultStr;
        }
        public static void Localice(IMappingOperationOptions<object, object> opt, LanguageDTO language, ILocalizedPropertyRepository localizedPropertyRepository)
        {
            opt.Items["Language"] = language;
            opt.Items["Repository"] = localizedPropertyRepository;
        }
    }
