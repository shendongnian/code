    public class RenderUtil
    {
        static Dictionary<Type, object> s_renderers;
    
        static RenderUtil()
        {
            s_renderers = new Dictionary<Type, object>();
    
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var renderInterface = type.GetInterfaces().FirstOrDefault(
                    i => i.IsGenericType && 
                         i.GetGenericTypeDefinition() == typeof(IRenderer<>));
    
                if (renderInterface != null)
                {
                    s_renderers.Add(
                        renderInterface.GetGenericArguments()[0],
                        Activator.CreateInstance(type));
                }
            }
        }
    
        public static string Render<T>(T item)
        {
            IRenderer<T> renderer = null;
            try
            {
                // no need to synchronize readonly access
                renderer = (IRenderer<T>)s_renderers[item.GetType()];
            }
            catch
            {
                throw new ArgumentException("No renderer for type " + item.GetType().Name);
            }
    
            return renderer.Render(item);
        }
    }
