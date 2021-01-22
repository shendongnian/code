    int x;
    Foo(ref x); // Invalid: x isn't definitely assigned
    Bar(out x); // Valid even though x isn't definitely assigned
    Console.WriteLine(x); // Valid - x is now definitely assigned
    ...
    
    public void Foo(ref int y)
    {
        Console.WriteLine(y); // Valid
        // No need to assign value to y
    }
    public void Bar(out int y)
    {
        Console.WriteLine(y); // Invalid: y isn't definitely assigned
        if (someCondition)
        {
            // Invalid - must assign value to y before returning
            return;
        }
        else if (someOtherCondition)
        {
            // Valid - don't need to assign value to y if we're throwing
            throw new Exception();
        }
        else
        {
            y = 10;
            // Valid - we can return once we've definitely assigned to y
            return;
        }
    }
