    // in some static class
    public static Test<NewT> Cast<T, NewT>(this Test<T> test) where T : NewT {
        // now "something" has to be both public and writable :(
        return new Test<NewT>() { something = test.something }; 
        // alternatively, write a constructor so that you can do this:
        // return new Test<NewT>(test.something)
        // now "something" only has to be publicly readable and privately writable, or not writable at all
    }
