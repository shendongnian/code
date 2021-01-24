        public IEnumerable<T> GetListTarget<T>(bool applyWhere) // You will need to add an constraint here that is applicable to both classes. Only then compiler will be able to understand the properties you are using in the where method
        {
            if (applyWhere)
            {
                return targetUnitOfWork
                     .Query<T>()
                     .Where(i => i.Name.Equals(otherObj.Name)).Where(j => j.SortKey == otherObj.SortKey);
            }
            else
            {
                return targetClassInfo.CreateNewObject(targetUnitOfWork);
            }
        }
