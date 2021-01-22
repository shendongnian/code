    public static bool operator ==(EntityBase<T> entity1, EntityBase<T> entity2)
            {
                if ((object)entity1 == null && (object)entity2 == null)
                {
                    return true;
                }
    
                if ((object)entity1 == null || (object)entity2 == null)
                {
                    return false;
                }
    
                if (Comparer<T>.Default.Compare(entity1.Id, entity2.Id) != 0)
                {
                    return false;
                }
    
                return true;
            }
