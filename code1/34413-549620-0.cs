    public Output MyServiceMethod(Input input, string transactionId)
    {
        using(new Tracer("MyServiceMethod: " + transactionId))
        {
            ... stuff ...
            return output;
        }
    }
