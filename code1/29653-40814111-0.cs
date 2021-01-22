    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class KonamiSequence
        {
            private readonly Keys[] _code = { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
            private int _index = 0;
    
            public bool IsCompletedBy(Keys key)
            {
                if (key == _code[_index]) {
                    if (_index == _code.Length - 1) {
                        _index = 0;
                        return true;
                    }
                    ++_index;
                } else {
                    _index = 0;
                }
    
                return false;
            }
        }
    }
