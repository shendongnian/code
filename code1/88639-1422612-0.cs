    Class Message
    {
        char buffer[10000];
    }
    Message Encrypt(Message message)  // Here you are making a copy of message
    {
        for(int loop =0;loop < 10000;++loop)
        {
            plop(message.buffer[loop]);
        }
        return message;  // Here you are making another copy of message
    }
