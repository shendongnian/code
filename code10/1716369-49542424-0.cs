    public interface IBaseDTO
    {
    }
    public abstract class BaseDTO<T> : IBaseDTO
            where T : BaseEntity
    {
    }
    public abstract class BaseListDTO<T> : IBaseDTO
        where T : IEnumerable<BaseEntity>
    {
    }
