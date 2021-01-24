            if (_voiceInfo == null)
            {
                _voiceInfo =
                    (
                        from voice in SpeechSynthesizer.AllVoices
                        where voice.Language == "fi-FI"
                        select voice
                    ).FirstOrDefault() ?? SpeechSynthesizer.DefaultVoice;
                textBlock.Text = _voiceInfo.Language;
            }
