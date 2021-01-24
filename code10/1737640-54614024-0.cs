    using System;
    using JetBrains.Annotations;
    
    namespace SpeechRecognition
    {
        public static class ResharperHelper
        {
            [SourceTemplate]
            public static void cw(this string str)
            {
                Console.WriteLine(str);
                //$ $END$
            }
        }
    }
