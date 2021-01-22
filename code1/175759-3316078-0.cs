    private void ReadText()
            {
                int iCounter = 0;
                while (Convert.ToInt32(numericUpDown1.Value) > iCounter)
                {
                    SpVoice spVoice = new SpVoice();
                    spVoice.Speak("Hello World", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                    spVoice.WaitUntilDone(Timeout.Infinite);
                    iCounter = iCounter + 1;
                }
            }
