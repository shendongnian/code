       SpFileStream fs = null;
        try
        {
        	SpVoice voice = new SpVoice();
        	fs = new SpFileStream();
        	fs.Open(@"c:\hello.wav", SpeechStreamFileMode.SSFMCreateForWrite, false);
        	voice.AudioOutputStream = fs;
        	voice.Speak("Hello world.", SpeechVoiceSpeakFlags.SVSFDefault);
        }
        finally
        {
        	if (fs != null)
        	{
        		fs.Close();
        	}
        }
