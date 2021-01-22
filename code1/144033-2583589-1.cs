    private void Method1(int one, int two)  
    {  
        SomeClass USER;  // This doesn't create an instance!
        USER = new SomeClass(); //This creates an instance.
        //SomeClass USER = new SomeClass(); //Can also be written as one-liner.
        Squid RsP = new Squid();  
        RsP.sqdReadUserConf(USER); // Able to pass 'USER' to class method in different file.
    }  
