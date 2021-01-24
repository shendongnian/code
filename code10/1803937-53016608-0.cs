    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace sandcastle1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //we create a mapper instance
                var _mapper = new MapperConfiguration(m =>
                {
                    m.CreateMap<A, ADto>().ForMember(x => x.Y, opt => opt.MapFrom(x => x.X));
                    m.CreateMap<B, BDto>().ForMember(x => x.bar, opt => opt.MapFrom(x => x.foo));
                }).CreateMapper();
    
                //some dummy POCOs that we can map
                var a1 = new A { X = 1 };
                var a2 = new A { X = 2 };
                var a3 = new A { X = 3 };
    
                var b1 = new B { foo = 1 };
                var b2 = new B { foo = 2 };
                var b3 = new B { foo = 3 };
    
                //mapping objects with fluent syntax:
                // -- we do not repeat the mapper as a written parameter
                // -- we do not specify the destination type but assume that there is exactly one TypeMap for the source type
                var result = _mapper
    
                    .Map(a1)
                    .Map(a2)
                    .Map(a3)
    
                    .Map(b1)
                    .Map(b2)
                    .Map(b3);
    
    
                //presenting the mapping result
                var cnt = 1;
                foreach (var dto in result)
                {
                    var propinfo = dto.GetType().GetProperties().First();
                    Console.WriteLine($"Mapped object {cnt++} is of Type {dto.GetType().Name} with {propinfo.Name} = {propinfo.GetValue(dto)}");
                }
            }
        }
    
    
        //our dummy classes for the mapping
        public class A
        {
            public int X { get; set; }
        }
        public class ADto
        {
            public int Y { get; set; }
        }
        public class B
        {
            public int foo { get; set; }
        }
        public class BDto
        {
            public int bar { get; set; }
        }
    
    
    
        public static class ExtensionMethodClass
        {
            //the first extension method ... 
            //takes the IMapper and maps the first object 
            //hands down all possible type mappings or throws an exception when we do not have exactly one mapping for the source type
            public static MyFluentResult Map(this IMapper _mapper, object source)
            {
                //build a dictionary that gives us access to information about existing TypeMaps in the Mapper 
                //(we only want to know from wicht source type to which destination type)
                var maps = _mapper.ConfigurationProvider.GetAllTypeMaps().GroupBy(x => x.SourceType).Where(x => x.Count() == 1).ToDictionary(x => x.Key, x => x.First().DestinationType);
                Type stype = source.GetType();
                Type dtype;
                if (!maps.TryGetValue(stype, out dtype))
                {
                    throw new Exception($"No suitable single mapping found for {stype.Name}");
                }
                //the magic happens here, we aggregate all necessary information for the following steps in this object
                return new MyFluentResult
                {
                    Mapper = _mapper,
                    Maps = maps,
                    ResultsSoFar = new object[] { _mapper.Map(source, stype, dtype) }
                };
            }
            //this method is called for the second and all subsequent mapping operations
            public static MyFluentResult Map(this MyFluentResult _fluentResult, object source)
            {
                //same as above, but we already have the dictionary...
                Type stype = source.GetType();
                Type dtype;
                if (!_fluentResult.Maps.TryGetValue(stype, out dtype))
                {
                    throw new Exception($"No suitable single mapping found for {stype.Name}");
                }
                //again we hand down the result and all other information for the next fluent call
                return new MyFluentResult
                {
                    Mapper = _fluentResult.Mapper,
                    Maps = _fluentResult.Maps,
                    //we can simply concat the results here
                    ResultsSoFar = _fluentResult.ResultsSoFar.Concat(new object[] { _fluentResult.Mapper.Map(source, stype, dtype) })
                };
            }
            //omitted implementation for IEnumerable sources... but that would look pretty much the same
        }
    
        //the class that holds the aggregated data.... the mapper... the possible typemaps ... and the result data...
        //wrapped IEnumerable of the results for convinience
        public class MyFluentResult : IEnumerable<object>
        {
            public IMapper Mapper { get; set; }
            public IEnumerable<object> ResultsSoFar { get; set; }
            public Dictionary<Type, Type> Maps { get; set; }
    
            public IEnumerator<object> GetEnumerator()
            {
                return ResultsSoFar.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ResultsSoFar.GetEnumerator();
            }
        }
    }
