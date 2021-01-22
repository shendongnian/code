    using System.Windows.Forms;
    namespace WindowsApplication1
    {
        public class KonamiSequence
        {
            readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
            private int _sequenceIndex;
            private readonly int _codeLength;
            private readonly int _sequenceMax;
            public KonamiSequence()
            {
                _codeLength = _code.Length - 1;
                _sequenceMax = _code.Length;
            }
            public bool IsCompletedBy(Keys key)
            {           
                _sequenceIndex %= _sequenceMax;
                if (_code[_sequenceIndex] == key) _sequenceIndex++;
                else  _sequenceIndex = 0;
                return _sequenceIndex > _codeLength;
            }
        }
    }
