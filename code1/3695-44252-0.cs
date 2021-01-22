    using(IEnumerator<Entity> e = entityList.GetEnumerator()) {
        while(e.MoveNext()) {
            Entity entity = e.Current;
            ...
        }
    }
