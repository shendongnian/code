    using System;
    using System.Windows.Forms;
    using Timer=System.Timers.Timer;
    namespace WindowsApplication1
    {
        public class KonamiSequence
        {
            readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
            private int _sequenceIndex;
            private readonly int _codeLength;
            private readonly int _sequenceMax;
            private readonly Timer _quantum = new Timer();
            public KonamiSequence()
            {
                _codeLength = _code.Length - 1;
                _sequenceMax = _code.Length;
                _quantum.Interval = 3000; //ms before reset
                _quantum.Elapsed += timeout;
            }
            public bool IsCompletedBy(Keys key)
            {   
                _quantum.Start();      
                _sequenceIndex %= _sequenceMax;
                _sequenceIndex = (_code[_sequenceIndex] == key) ? ++_sequenceIndex : 0;
                return _sequenceIndex > _codeLength;
            }
            private void timeout(object o, EventArgs e)
            {
                _quantum.Stop();
                _sequenceIndex = 0;
                
            }
        }
    }
