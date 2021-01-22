    void A()
    {
       _answer = 123;
       WriteWithReleaseBarrier(_complete, true);  // "publish" values
    }
    void B()
    {
       if (ReadWithAcquire(_complete))  // subscribe
       {  
          Console.WriteLine (_answer);
       }
    }
