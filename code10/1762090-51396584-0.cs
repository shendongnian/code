    public void MyAPI(ApiViewModel vm) 
    {
     var entity = _dbContext.Find(tag.Id);
     entity.Value = vm.Value;
     _dbContext.SaveChanges();
     return Ok();
    }
