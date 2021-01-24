        public class AutoMapperProfile : Profile
        {
           public AutoMapperProfile()
           {
              CreateMap<Article, ArticleViewModel>()
                  .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ArticleTags.Select(at => at.Tag)));
              CreateMap<Tag, TagViewModel>();
           }
        }
