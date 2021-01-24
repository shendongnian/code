     public class Tester 
     {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        public void Dispose() 
        {
             ss.Dispose();
             sre.Dispose();
        }
     }
 
