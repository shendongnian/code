    public interface IMapper<TSource, TDestination> {
       public TDestination Map(TSource source);
    }
    
    public class FormToEnityMap : IMapper<Form, Entity> {
       public Entity Map(Form source){
       
       }
    }
    
    public class EntityToFormMap : IMapper<Entity, Form> {
       public Form Map(Entity source) {
    
       }
    }
