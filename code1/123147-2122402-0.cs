     public class ComposedType<TValue, TContext>
     {
           public TValue Value { get; protected set; }
           public TContext Context { get; protected set; }
           
           public ComposedType(TValue value, TContext context)
           {
                Value = value;
                Context = context;
           }
      }
