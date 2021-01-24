    namespace Common.Mapper
    {
        public interface IMapper
        {
            void Map(...args...);
        }
    }
    namespace Web.Mapper
    {
        public class Mapper : Common.Mapper.IMapper
        {
            public void Map(...args...)
            {
                AutoMapper.Map(...args...);
            }
        }
    }
    namespace Core.Mapper
    {
        public class Mapper : Common.Mapper.IMapper
        {
            public void Map(...args...)
            {
                SomeOtherMapper.Map(...args...);
            }
        }
    }
