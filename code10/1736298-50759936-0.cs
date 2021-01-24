        // deviceno is an index of the returned devices from enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        void StartAudioDevice(int deviceno)
        {            
        
            if (deviceno >= 0)
            {
                try
                {
                    wavIn = new WaveInEvent();
                    wavIn.DeviceNumber = deviceno;
                    wavIn.WaveFormat = new WaveFormat(44100, 1);                    
                    wavIn.StartRecording();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
        void StopAudioDevice()
        {
            try
            {
                wavIn.StopRecording();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        
