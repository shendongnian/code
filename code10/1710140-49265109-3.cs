        [Route("api/Task")]
        public void Delete(int id,int id2, string id3)
        {
            TaskPersistent tp = new TaskPersistent();
            tp.deleteTask(id,id2,id3);
        }
