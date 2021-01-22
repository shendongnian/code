    public class MyClass
    {
        private static List<WeakReference> instances = new List<WeakReference>();
    
        public MyClass()
        {
             instances.Add(new WeakReference(this));
        }
    
        public IList<MyClass> GetInstances()
        {
            List<MyClass> realInstances = new List<MyClass>();
            List<WeakReference> toDelete = new List<WeakReference>();
    
            foreach(WeakReference reference in instances)
            {
                if(reference.IsAlive)
                {
                    realInstances.Add((MyClass)reference.Target);
                }
                else
                {
                    toDelete.Add(reference);
                }
            }
    
            foreach(WeakReference reference in toDelete) instances.Remove(reference);
    
            return realInstances;
        }
    }
