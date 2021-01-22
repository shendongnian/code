    Generic_lib.IMessage msg = Generic_lib.Message_Handler.get_message(2); //a Center Message
    if (msg is Center_lib.Center_Message)
    {
        System.Console.WriteLine("got center message");
    }
