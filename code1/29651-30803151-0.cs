    public class KonamiSequence
    {
        private static readonly Keys[] KonamiCode = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
        private readonly Queue<Keys> _inputKeys = new Queue<Keys>();
        public bool IsCompletedBy(Keys inputKey)
        {
            _inputKeys.Enqueue(inputKey);
            while (_inputKeys.Count > KonamiCode.Length)
                _inputKeys.Dequeue();
            return _inputKeys.SequenceEqual(KonamiCode);
        }
    }
