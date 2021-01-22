        byte[] ITextReader.SpeakText(string text)
        {
            using (SpeechSynthesizer s = new SpeechSynthesizer())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    s.SetOutputToWaveStream(ms);
                    s.Speak(text);
                    return ms.GetBuffer();
                }
            }
        }
