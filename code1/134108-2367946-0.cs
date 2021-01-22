    public IObservable<Collision<T1, T2>> onCollisionsOf<T1, T2>()
        where T1 : Entity
        where T2 : Entity
    {
        EntityTypeEnum t1 = T1.EntityType;
        EntityTypeEnum t2 = T2.EntityType;
        Subject<Collision<T1, T2>> obs = new Subject<Collision<T1, T2>>();
        _onCollisionInternal += delegate(Entity obj1, Entity obj2)
        {
           if (t1 < t2)
               obs.OnNext(new Collision<T1, T2>((T1) obj1, (T2) obj2));
           else
               obs.OnNext(new Collision<T1, T2>((T1) obj2, (T2) obj1));
        };
        return obs;
    }
