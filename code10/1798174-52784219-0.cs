    public void CreateObj(string value)
    {
       Object newObj = Object(value);
       //Magic saving newObj to database
       int id = newObj.objectId; //Saves the object's id to a variable for demo purposes
       Edit(id);   // <-- Normal function call
    }
    
