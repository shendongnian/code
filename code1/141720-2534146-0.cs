    public static class SequentialSoundPlayer
    {
        private static Object _soundLock = new object();
        public static void PlaySound(Sound sound)
        {
            ThreadPool.QueueUserWorkItem(AsyncPlaySound, sound);
        }
        private static void AsyncPlaySound(Object state)
        {
            lock (_soundLock)
            {
                Sound sound = (Sound) state;
                //Execute your sound playing here...
            }
        }
    }
