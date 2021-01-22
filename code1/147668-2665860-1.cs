            var array = new T[sourceEntityCollection.Count()];
            sourceEntityCollection.CopyTo(array,0);
         
            foreach (var entity in array)
            {
                destinationEntityCollection.Add(entity);
            }
        }
