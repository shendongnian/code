    class SoundPlayer
    {
        
        public void Play(...)
        {
            var h = GCHandle.Alloc(this);
            SomeNativeAPI.Play(this, h.ToIntPtr());
        }
    
        // assuming this is your callback when playing has finished
        delegate void FinishedCallback(IntPtr userData);
        static FinishedCallback finishedCallback = OnPlayingFinished;
        public static void OnPlayingFinished(IntPtr userData)
        {
            var h = GCHandle.FromIntPtr(userData);
            SoundPlayer This = (SoundPlayer)h.Target;
            h.Free();
            ... // use 'This' as your object
        }
    }
