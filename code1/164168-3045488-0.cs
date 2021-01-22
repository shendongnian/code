    using System;
    using System.Speech.Synthesis;  // Add reference to System.Speech
    
    class Program {
        static void Main(string[] args) {
            var synth = new SpeechSynthesizer();
            foreach (var voice in synth.GetInstalledVoices()) {
                Console.WriteLine(voice.VoiceInfo.Description);
            }
            Console.ReadLine();
        }
    }
