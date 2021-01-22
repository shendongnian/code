    public class SimpleMapper<TFrom, TTo>
    {
        public static TTo Map(TFrom fromModel)
        {
            Mapper.CreateMap<TFrom, TTo>();
            return Mapper.Map<TFrom, TTo>(fromModel);
        }
        public static IList<TTo> MapList(IList<TFrom> fromModel)
        {
            Mapper.CreateMap<TFrom, TTo>();
            return Mapper.Map<IList<TFrom>, IList<TTo>>(fromModel);
        }
    }
    public class RepositoryBase<TModel, TLINQModel>
    {
        public IList<TModel> Map<TCustom>(IList<TCustom> model)
        {
            return SimpleMapper<TCustom, TModel>.MapList(model);
        }
        public TModel Map(TLINQModel model)
        {
            return SimpleMapper<TLINQModel, TModel>.Map(model);
        }
        public TLINQModel Map(TModel model)
        {
            return SimpleMapper<TModel, TLINQModel>.Map(model);
        }
        public IList<TModel> Map(IList<TLINQModel> model)
        {
            return SimpleMapper<TLINQModel, TModel>.MapList(model);
        }
        public IList<TLINQModel> Map(IList<TModel> model)
        {
            return SimpleMapper<TModel, TLINQModel>.MapList(model);
        }
    }
