    public List<MyModel> DoAThing()
    {
        List<MyModel> myList = new List<MyModel>();
        MyModel addThing = new MyModel();
        addThing.Name = "Tomato";
        addThing.Colour = "Red";
        myList.Add(addThing);
        
        return myList;
    }
