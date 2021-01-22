    private class BrutePasswordGuesser
    {
        private const int MaxAscii = 126;
        private const int MaxSize = 3;
        private const int MinAscii = 33;
        private int _currentLength;
        public BrutePasswordGuesser()
        {
            //Init the length, and current guess array.
            _currentLength = 0;
            CurrentGuess = new char[MaxSize];
            CurrentGuess[0] = (char) MinAscii;
        }
        public char[] CurrentGuess { get; private set; }
        public bool NextGuess()
        {
            if (_currentLength >= MaxSize)
            {
                return false;
            }
            //Increment the previous digit (Uses recursion!)
            IncrementDigit(_currentLength);
            return true;
        }
        /// <summary>
        /// Increment the character at the index by one. If the character is at the maximum 
        /// ASCII value, set it back to the minimum, and increment the previous character.
        /// Use recursion to do this, so that the proggy will step all the way back as needed.
        /// If the very bottom of the string is reached, add another character to the guess.
        /// </summary>
        /// <param name="digitIndex"></param>
        private void IncrementDigit(int digitIndex)
        {
            //Don't fall out the bottom of the array.
            //If we're at the bottom of the array, add another character
            if (digitIndex < 0)
            {
                AddCharacter();
            }
            else
            {
                //If the current character is max ASCII, set to min ASCII, and increment the previous char.
                if (CurrentGuess[digitIndex] == (char) MaxAscii)
                {
                    CurrentGuess[digitIndex] = (char) MinAscii;
                    IncrementDigit(digitIndex - 1);
                }
                else
                {
                    CurrentGuess[digitIndex]++;
                }
            }
        }
        private void AddCharacter()
        {
            _currentLength++;
            //If we've reached our maximum guess size, leave now and don't come back.
            if (_currentLength >= MaxSize)
            {
                return;
            }
            //Initialis as min ASCII.
            CurrentGuess[_currentLength] = (char) (MinAscii);
        }
    }
