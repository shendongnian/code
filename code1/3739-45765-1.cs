    void DoIt()
    {
        String foo = "bar";
        Switch(foo, foo);
    }
    void Switch(String val1, String val2)
    {
        switch ("bar")
        {
            case val1:
                // Is this case block selected?
                break;
            case val2:
                // Or this one?
                break;
            case "bar":
                // Or perhaps this one?
                break;
        }
    }
