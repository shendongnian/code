            Thread t = new Thread(() =>
            {
                SpeechSynthesizer audio = new SpeechSynthesizer(); 
                audio.Speak(textBox1.Text);
            });
            t.Start();
