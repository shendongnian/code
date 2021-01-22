    _onCollisionInternal += delegate(T1 obj1, T2 obj2) {
      obs.OnNext(new Collision<T1, T2>( obj1, obj2));
    };
    public IObservable<Collision<T1, T2>> onCollisionsOf<T1, T2>()
            where T1 : Entity
            where T2 : Entity
        {
            Subject<Collision<T1, T2>> obs = new Subject<Collision<T1, T2>>();
            _onCollisionInternal += delegate(T1 obj1, T2 obj2) {
               obs.OnNext(new Collision<T1, T2>( obj1, obj2));
            };
            return obs;
        }
    Observable<Collision<Laser, Player>> lp = onCollisionsOf<Laser, Player>();
    Observable<Collision<Laser, Laser>> ll = onCollisionsOf<Laser, Laser>();
