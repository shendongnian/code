    public class TextAndSpeech
    {
        private readonly WhateverSIs s;
        public TextAndSpeech(WhateverSIs s)
        {
            this.s = s;
        }
        public Spurt(string message)
        {
            Console.WriteLine(message);
            s.Speak(message);
        }
    }
