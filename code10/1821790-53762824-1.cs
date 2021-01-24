       public class YourClass
        {
            private Queue<IInitializable> objectsToLoad = new Queue<IInitializable>();
    
            public void Enqueue(IInitializable obj)
            {
                this.objectsToLoad.Enqueue(obj);
            }
    
            public void LoadOrUpdate()
            {
                // Update Method
                if (objectsToLoad.Count > 0)
                {
                    IInitializable obj = objectsToLoad.Dequeue();
                    obj.Initialize();
                }
                else
                {
                    // Loading complete.
                }
            }
        }
