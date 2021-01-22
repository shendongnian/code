    public class Global {
        private static readonly List<Resource> Disposables = new List<Resource>();
    
        public HeavyLifter GetHeavyLifter()
        {
            var resource = new HeavyLifterResource();
            var heavyLifter = new HeavyLifter(resource);
            resource.BusinessObject = heavyLifter;
            Disposables.Add(resource);
        }
    
        public void DisposeAll()
        {
            Disposables.ForEach(d => d.CleanUp());
        }
    }
    
    public abstract class Resource : IDisposable {
    
        WeakReference<object> m_BusinessObject;
        public WeakReference<object> BusinessObject {get;set;}
    
        public CleanUp() {
          if (!m_BusinessObject.IsAlive)
            Dispose();
        }
    }
    
    public HeavyLifter {
        public HeavyLifter (Disposable d) {
          m_resourceObj = d;
        }
    
        HeavyLifterResource m_resourceObj;
    }
    
    public class HeavyLifterResource :Resource {
        public void Dispose() {
          //disposal
        }
    }
