    Move( new Cat() );
    Move( new Pigeon() );
    public void Move(object objectToMove)
    {
        if(objectToMove is Cat)
        {
            Cat catObject = objectToMove as Cat;
            catObject.Walk();
        }
        else if(objectToMove is Pigeon)
        {
            Rat pigeonObject = objectToMove as Pigeon;
            pigeonObject.Fly();
        }
    }
