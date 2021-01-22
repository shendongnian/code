    public IEnumerable<T> Get(Func<T, bool> conditionLambda){
      using(var db = new DbContext()){
        return db.Set<T>.Where(conditionLambda);
      }
    }
