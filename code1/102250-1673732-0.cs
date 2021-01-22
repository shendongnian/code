    CheckForNull(MyType element)
    {
        if(element.ChildElement != null)
        {
            CheckForNull(element.ChildElement);
        }
        else
        {
            Console.WriteLine("Null Found");
        }
    }
