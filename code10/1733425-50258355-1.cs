    public class Processor
    {
      private readonly IHandler[] _handlers;
      public Processor(IEnumerable<Meta<Lazy<IHandler>>> handlers)
      {
        this._handlers =
          handlers
            .Where(h => h.Metadata["type"] == HandlerType.One || h.Metadata["type"] == HandlerType.Three)
            .Select(h => h.Value.Value)
            .ToArray();
      }
    }
