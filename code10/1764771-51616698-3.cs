    public class ApplicationModel2ApplicationDto : ITypeConverter<ApplicationModel, ApplicationDto>
    {
        public ApplicationDto Convert(ApplicationModel source, ApplicationDto destination, ResolutionContext context)
        {
            var mapper = context.Mapper;
            try
            {
                destination = new ApplicationDto
                { 
                    ApplicationId = source.ApplicationId,
                    ApplicationName = source.ApplicationName,
                    Documents = mapper.Map<IEnumerable<DocumentDto>>(source.Documents),
                    Tags = mapper.Map<IEnumerable<TagInfoDto>>(source.TagInfos)
                };
            }
            catch
            {
                return null;
            }
            return destination;
        }
    }
