    MyRepo<MyEntity> myRepo = new MyRepo<MyEntity>();
    Func<MyEntity, bool> predicate = x => x.Id == 1;
    Expression<Func<MyEntity, bool>> expression = x => x.Id == 1;
    // both below lines are fine now
    myRepo.GetData(predicate);
    myRepo.GetData(expression);
