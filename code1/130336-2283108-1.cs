    public enum WhatHappened
    {
        Copy,
        Rename,
        Delete
    }
    public class FileEventArgs : EventArgs
    {
        public FileEventArgs(string filename, WhatHappened whatHappened)
        {
            Filename = filename;
            WhatHappened = whatHappened;
        }
        public string Filename { get; private set; }
        public WhatHappened WhatHappened { get; private set; }
    }
