    void method()
    {
        list<string> strings = new list<string>();
        dostuff += stuff;
        dostuff += stuff;
        dostuff(this, new EventHandlerArgs(){ Parameter = strings })
        foreach(string currString in strings)
        {
              //....
        }
    }
    void stuff(object sender, EventHandlerArgs e)
    {
        list<string> strings = e.Parameter as list<string>;
        if (strings != null)
        {
            strings.Add(MyString)
        }
    }
