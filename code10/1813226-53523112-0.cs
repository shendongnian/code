    public void prepareAudioUnit()
        {
            var _audioComponent =   AudioComponent.FindComponent(AudioTypeOutput.VoiceProcessingIO);
            audioUnit = new AudioUnit.AudioUnit(_audioComponent);
            audioUnit.SetEnableIO(true,
                AudioUnitScopeType.Input,
                1 // Remote Input
            );
            // setting audio format
            audioUnit.SetAudioFormat(audioStreamBasicDesc,
                AudioUnitScopeType.Output,
                1
            );                                    
            audioUnit.SetInputCallback(input_CallBack, AudioUnitScopeType.Input, 1);
            audioUnit.SetRenderCallback(render_CallBack, AudioUnitScopeType.Global, 0);
            audioUnit.Initialize();
            audioUnit.Start();
        }
