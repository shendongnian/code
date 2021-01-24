    test abc = null;
    
    void OnExplosiveThrown(BasePlayer player, BaseEntity entity, InputState input)
    {
        if (Test == true )
         {
            abc = entity as test;
         }
    
    }
    
    void Unload(BaseEntity entity)        ------//This CODE CANT SEE abc //------
    {
         entity.Kill(abc);
    }
