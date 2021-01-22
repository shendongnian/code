    int i = 0;
    while (true)
    {
        if (i < 5)
        {
            yield return i;
        }
        else
        {
            // note that i++ will not be executed after this
            yield break;
        }
        i++;
    }
    Console.Out.WriteLine("Won't see me");
