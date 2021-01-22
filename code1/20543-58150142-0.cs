        for example:
        public void ShowEnglishAlphabet()
        {
            var firstLetter = 'a';
            var endLetter = 'z';
            for (var letter = firstLetter; letter <= endLetter; letter++)
            {
                Console.WriteLine($"{letter}-{letter.ToString().ToUpper()}");
            }
        }
        public void ShowEnglishAlphabetFromUnicodeTableDecNumber()
        {
            var firstLetter = 97;
            var endLetter = 122;
            for (var letterNumberUnicodeTable = firstLetter; letterNumberUnicodeTable <= endLetter; letterNumberUnicodeTable++)
            {
                Console.WriteLine($"{(char)letterNumberUnicodeTable}-{((char)letterNumberUnicodeTable).ToString().ToUpper()}");
            }
        }
        public void ShowEnglishAlphabetUnicodeTableEscapeSequence()
        {
            var firstLetter = '\u0061';
            var endLetter = '\u007A';
            for (var letterNumberUnicodeTable = firstLetter; letterNumberUnicodeTable <= 
               endLetter; letterNumberUnicodeTable++)
            {
                Console.WriteLine($"{letterNumberUnicodeTable}-{letterNumberUnicodeTable.ToString().ToUpper()}");
            }
        }   
 
