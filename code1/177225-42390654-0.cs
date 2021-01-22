        public class NumberConverter : ITypeConverter<DTO, NumberBase>
        {
            public NumberBase Convert(DTO source, NumberBase destination, ResolutionContext context)
            {
                if (source.Id % 2 == 0)
                {
                    return context.Mapper.Map<EvenNumber>(source);
                }
                else
                {
                    return context.Mapper.Map<OddNumber>(source);
                }
            }
        }
