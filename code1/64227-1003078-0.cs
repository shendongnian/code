    Type key = message.GetType();
    if (key == typeof(Foo))
    {
        MessageProcessor<Foo> processor = (MessageProcessor<Foo>)messageProcessors[key];
        // Do stuff with processor
    }
    else if (key == typeof(Bar))
    {
        MessageProcessor<bar> processor = (MessageProcessor<Bar>)messageProcessors[key];
        // Do stuff with processor
    }
    ...
