    case just_before_try_state:
        try
        {
            Console.WriteLine("a");
        }
        catch (Something e)
        {
            CatchBlock();
            goto case post;
        }
        __current = 10;
        return true;
    case just_after_yield_return:
        try
        {
            Console.WriteLine("b");
        }
        catch (Something e)
        {
            CatchBlock();
        }
        goto case post;
    case post;
        Console.WriteLine("Post");
    void CatchBlock()
    {
        Console.WriteLine("Catch block");
    }
