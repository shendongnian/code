    [HttpPost]
    [Route("api/Task")]
     public void Delete([FromBody] YourViewModel model)
     {
         TaskPersistent tp = new TaskPersistent();
         tp.deleteTask(model.Id1, model.Id2, model.Id3);
     }
