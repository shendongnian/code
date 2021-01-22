    public Actor AddOrUpdate(Actor entity)
    {
        Actor cur = context.Actors.Where(l => l.Name == entity.Name && l.Last_Name == entity.Last_Name).FirstOrDefault();
        if (cur == null)
        {
            context.Actors.AddObject(entity);
            return entity;
        }
        else
        {
            if (!entity.Mail.IsNullOrEmptyOrWhitespace() && cur.Mail != entity.Mail)
                cur.Mail = entity.Mail;
    	//there are more of these...
    
            return cur;
        }
    }
