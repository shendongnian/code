        private void TryGetVolumeControl()
        {
            int waveInDeviceNumber = waveIn.DeviceNumber;
            if (Environment.OSVersion.Version.Major >= 6) // Vista and over
            {
                var mixerLine = new MixerLine((IntPtr)waveInDeviceNumber, 0, MixerFlags.WaveIn);
                foreach (var control in mixerLine.Controls)
                {
                    if (control.ControlType == MixerControlType.Volume)
                    {
                        volumeControl = control as UnsignedMixerControl;
                        MicrophoneLevel = desiredVolume;
                        break;
                    }
                }
            }
            else
            {
                var mixer = new Mixer(waveInDeviceNumber);
                foreach (var destination in mixer.Destinations)
                {
                    if (destination.ComponentType == MixerLineComponentType.DestinationWaveIn)
                    {
                        foreach (var source in destination.Sources)
                        {
                            if (source.ComponentType == MixerLineComponentType.SourceMicrophone)
                            {
                                foreach (var control in source.Controls)
                                {
                                    if (control.ControlType == MixerControlType.Volume)
                                    {
                                        volumeControl = control as UnsignedMixerControl;
                                        MicrophoneLevel = desiredVolume;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
