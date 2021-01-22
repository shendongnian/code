    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    
    namespace KonamiCode {
    
        public class KonamiSequence {
    
            List<Key> Keys = new List<Key>{Key.Up, Key.Up, 
                                           Key.Down, Key.Down, 
                                           Key.Left, Key.Right, 
                                           Key.Left, Key.Right, 
                                           Key.B, Key.A};
            private int mPosition = -1;
    
            public int Position {
                get { return mPosition; }
                private set { mPosition = value; }
            }
    
            public bool IsCompletedBy(Key key) {
    
                if (Keys[Position + 1] == key) {
                    // move to next
                    Position++;
                }
                else if (Keys[0] == key) {
                    // restart at 1st
                    Position = 0;
                }
                else {
                    // no match in sequence
                    Position = -1;
                }
    
                if (Position == Keys.Count - 1) {
                    Position = -1;
                    return true;
                }
    
                return false;
            }
    
        }
    }
