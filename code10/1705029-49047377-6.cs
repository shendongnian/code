    public class R : IMReceiver
    {
        void IMReceiver.accept( S sender, M message){} // <= explicit interface implementation.
                                                       // only visible when the reference is of 
                                                       // that interface type.
        public void accept( X sender, N message){} // you would do the same for N ...
    }
