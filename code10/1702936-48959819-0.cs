    using AutoMapper;
    using Xunit;
    
    using System.Linq;
    using System.Collections.Generic;
    
    namespace AutoMapperTest
    {
        public class LocalisedPromotion
        {
            public int Id;
            public int CultureId;
        }
    
        public class LocalisedPromotionViewModel
        {
            public int LocalisedPromotionId;
        }
    
        public class Promotion
        {
            public List<LocalisedPromotion> LocalisedPromotions;
            public int DefaultCultureId;
        }
    
        public class PromotionViewModel
        {
            public LocalisedPromotionViewModel DefaultLocalisedPromotion;
        }
    
        public class AutoMapperTest
        {
            [Fact]
            public void Test()
            {
                var theConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<LocalisedPromotion, LocalisedPromotionViewModel>()
                        .ForMember(dest => dest.LocalisedPromotionId, o => o.MapFrom(src => src.Id));
    
                    config.CreateMap<Promotion, PromotionViewModel>()
                        .ForMember(dest => dest.DefaultLocalisedPromotion,
                                   o => o.MapFrom(src => src.LocalisedPromotions
                                                            .FirstOrDefault(x => x.CultureId == src.DefaultCultureId)));
                });
    
                var promotion = new Promotion { DefaultCultureId = 3 };
                promotion.LocalisedPromotions = new List<LocalisedPromotion>() { new LocalisedPromotion() { Id = 1, CultureId = 3 } };
    
                var result = theConfig.CreateMapper().Map<Promotion, PromotionViewModel>(promotion);
    
                Assert.NotNull(result.DefaultLocalisedPromotion);
                Assert.Equal(result.DefaultLocalisedPromotion.LocalisedPromotionId, 1);
            }
        }
    }
