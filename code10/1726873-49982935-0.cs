        private void SomeMethod<T>()
        {
            target = targetUnitOfWork
                .Query<T>()
                .Where(i => i.Name.Equals(otherObj.Name)).Where(j => j.SortKey == otherObj.SortKey);
        }
