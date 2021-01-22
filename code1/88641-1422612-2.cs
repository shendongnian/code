    void myFunc()
    {
        Message    m;
        // read message into m
        Encrypt(m);
    }
    void alternative()
    {
        boost::shared_pointer<Message>  m(new Message);
        EncryptUsingPointer(m);
    }
