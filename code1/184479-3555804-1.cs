    foreach(Dto dto in modifications.NewOrUpdatedItems)
    {
      if (dto.id == 0)
      {
        session.Save(DtoMapper.CreateEntity(dto));
      }
      else
      {
        Entity entity = session.Get<Entity>(dto.id);
        DtoMapper.Update(entity, dto);
      }
    }
    
    foreach(Identity identity in modifications.DeletedItems)
    {
      session.Delete<Entity>(identity.id);
    }
