    public class ListOfTypes
        {
            private List<IHandler> handlers;
            public ListOfTypes(IEnumerable<IHandler> handlers)
            {
                this.handlers = handlers.ToList();
            }
    
            public void PrintHandlers()
            {
                handlers.ForEach(_ => _.HandlerType());
            }
    
        }
