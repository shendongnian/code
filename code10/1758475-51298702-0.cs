    foreach (AbstractEntity ent in response.Entities)
                    {
                        //defining new Entry for context - action by state
                        ctx.Entry(ent).State = ent.getEntityState();
                        ctx.SaveChanges();
                        ctx.Entry(ent).State = EntityState.Detached;
                    } 
    
    
                    catch (Exception ex){
    string errorMessages = ex.InnerException.InnerException.ToString();
                    throw ex.InnerException.InnerException;}
                }
