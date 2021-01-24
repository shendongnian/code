    public ISomething CombinePersonWithSecret(
        IPublicPersonData publicPerson, 
        ISecretPersonData secret)
    {
        if(publicPerson.PersonId != secret.PersonId)
        {
            throw ...;
        }
        //join 2 params into a single entity
        return something;
    }
