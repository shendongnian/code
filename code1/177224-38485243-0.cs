    using System;
    using System.Linq;
    using AutoMapper;
    namespace ConsoleApplication19
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                //mapping
                Mapper.Initialize(expression =>
                {
                    expression.CreateMap<DTO, NumberBase>()
                        .ForMember(@class => @class.IdOnlyInDestination,
                            configurationExpression => configurationExpression.MapFrom(dto => dto.Id))
                        .ConvertUsing(dto =>//here is the function that creates appropriate object
                        {
                            if (dto.Id%2 == 0) return Mapper.Map<EvenNumber>(dto);
                            return Mapper.Map<OddNumber>(dto);
                        });
                    expression.CreateMap<DTO, OddNumber>()
                        .IncludeBase<DTO, NumberBase>();
                    expression.CreateMap<DTO, EvenNumber>()
                        .IncludeBase<DTO, NumberBase>();
                });
                //initial data
                var arrayDto = Enumerable.Range(0, 10).Select(i => new DTO {Id = i}).ToArray();
                //converting
                var arrayResult = Mapper.Map<NumberBase[]>(arrayDto);
                //output
                foreach (var resultElement in arrayResult)
                {
                    Console.WriteLine($"{resultElement.IdOnlyInDestination} - {resultElement.GetType().Name}");
                }
                Console.ReadLine();
            }
        }
        public class DTO
        {
            public int Id { get; set; }
            public int EvenFactor => Id%2;
        }
        public abstract class NumberBase
        {
            public int Id { get; set; }
            public int IdOnlyInDestination { get; set; }
        }
        public class OddNumber : NumberBase
        {
            public int EvenFactor { get; set; }
        }
        public class EvenNumber : NumberBase
        {
            public string EventFactor { get; set; }
        }
    }
