    public List<SentMessage> EmailAllFriends(Person p) {
        Requires.NotNull(p); //check if object is null
        Requires.NotNullOrEmpty(p.EmailAddress); //check if string property is null or empty
        Requires.NotNullOrEmpty(p.Friends); //check if sequence property is null or empty
        Ensures.NotNull(); //result object will not be null
        //Do stuff
    }
