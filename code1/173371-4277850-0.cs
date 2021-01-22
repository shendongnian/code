    private bool Collide(colObject obj1, colObject obj2, ref Vector3 projection, bool calcProjection)
    {
    
        //do a bunch of expensive operations to determine if there is collision
        if(!collided)return false;
        // Now instead of checking if projection is null, we just check if they requested it
        if(calcProjection)
        {
            //do more expensive operations, that make use of the above operations already done,
            //to determine the proj vect
            *proj = result;
        }
        return true;
    }
    
    public bool Collide(colObject obj1, colObject obj2, ref Vector3 projection)
    {
        return Collide(obj1, obj2, ref projection, true);
    }
    
    public bool Collide(colObject obj1, colObject obj2)
    {
        Vector3 dummy;
        return Collide(obj1, obj2, ref dummy, false);
    }
