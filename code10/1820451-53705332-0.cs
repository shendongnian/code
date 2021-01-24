    dynamic collection = Activator.CreateInstance(typeof(List<double>));
            if (collection.GetType() == typeof(Queue<double>))
            {
                collection.Enqueue(1);
            }
            else if(collection.GetType() == typeof(List<double>))
            {
                collection.Add(1);
            }
