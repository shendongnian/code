        public Models.Tag GetEntity()
        		{
        			var dbTag = db.PROJ_GetEntity((int)EntityStatuses.Created, (int)EntityStatuses.CreatingInApi).SingleOrDefault();
        			return FromDb Entity(dbEntity);
        		}
    
    
    var appModel = GetEntity(); // gets an Entity from a stored proc (NOT GetEntity_RESULT)
    
    appModel.MakeSomeChanges();
    
    _Repo.Persist(appModel);
    
    public void Persist(Models.AppModel model)
    {
    var dbEntity = Mapper.Map(model);
    db.Attach(dbEntity);
    db.SubmitChanges();
    }
