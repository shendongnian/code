    using System;
    using System.Speech.Synthesis;
    
    namespace SpeakToMe
    {
        class Program
        {
            static void Main(string[] args)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SetOutputToWaveFile("c:\\test.wav");
                synth.Speak("Hello, world.");
                synth.SetOutputToDefaultAudioDevice();
    
                Console.ReadLine();
            }
        }
    }
