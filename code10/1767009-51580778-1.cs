    string abc = ""; // use abc's type instead of string and assign a default value for it.
    
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
