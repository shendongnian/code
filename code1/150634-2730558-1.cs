    public class PixelMemoryLocker : ResourceReleaser<PixelMemory>
    {
        public PixelMemoryLocker(PixelMemory mem)
            : base(mem,
            (pm =>
                {
                    if (pm != null)
                        pm.Unlock();
                }
            ))
        {
            if (mem != null)
                mem.Lock();
        }
        public PixelMemoryLocker(AtalaImage image)
            : this(image == null ? null : image.PixelMemory)
        {
        }
    }
