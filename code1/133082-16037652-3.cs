    private bool check = false;
    protected override Update(GameTime gameTime)
    {
        if(!check)
        {    
            check = true;
            _allPossibleCollisions = GenerateAllPossibleCollisions();
            for(int i=0; i < _allPossibleCollisions.Length; i++)
            {
                if (CheckCollision(_allPossibleCollisions[i]))
                {
                    //Collision!
                }
            }
        }
    }
    
    protected override Draw(GameTime gameTime)
    {
        check = false;
    }
