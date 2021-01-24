    foreach (d in dictionary)
    {
        switch (d.Key)
        {
            case "foo": ... // known property
                obj.Foo = (bool)d.Value;
                break;
            case "bar": ... // known property
                obj.Bar = (Bar)d.Value;
                break;
            default: ...    // according to your comments, these are known types
                try
                {
                    obj.Files.Add((File)d.Value);
                }
                catch {...}
                break;
        }
    }
