    static int a = 7;
    static int b = 0;
    ...
    try
    {
        throw new InvalidDataException();
    }
    catch (Exception exception) when (exception is InvalidDataException && a / b == 2)
    {
        Console.WriteLine("Catch");
    }
    catch (Exception exception) when (exception is InvalidDataException || exception is ArgumentException)
    {
        Console.WriteLine("General catch");
    }
