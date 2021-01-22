    public class SoundPlayer : IDisposable
    {
        private int maxSize;
        private Queue<Sound> sounds = new Queue<Sound>(maxSize);
        private object sync = new Object();
        private Thread playThread;
        private bool isTerminated;
        public SoundPlayer(int maxSize)
        {
            if (maxSize < 1)
                throw new ArgumentOutOfRangeException("maxSize", maxSize,
                    "Value must be > 1.");
            this.maxSize = maxSize;
            this.sounds = new Queue<Sound>();
            this.playThread = new Thread(new ThreadStart(ThreadPlay));
            this.playThread.Start();
        }
        public void Dispose()
        {
            isTerminated = true;
            lock (sync)
            {
                Monitor.PulseAll(sync);
            }
            playThread.Join();
        }
        public void Play(Sound sound)
        {
            lock (sync)
            {
                if (sounds.Count == maxSize)
                {
                    return;   // Or throw exception, or block
                }
                sounds.Enqueue(sound);
                Monitor.PulseAll(sync);
            }
        }
        private void PlayInternal(Sound sound)
        {
            // Actually play the sound here
        }
        private void ThreadPlay()
        {
            while (true)
            {
                lock (sync)
                {
                    while (!isTerminated && (sounds.Count == 0))
                        Monitor.Wait(sync);
                    if (isTerminated)
                    {
                        return;
                    }
                    Sound sound = sounds.Dequeue();
                    Play(sound);
                }
            }
        }
    }
