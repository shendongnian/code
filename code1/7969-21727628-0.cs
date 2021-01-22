            public static void TestRecordPlayer()
            {
                RecordPlayer rp = new RecordPlayer();
                rp.PropertyChanged += new PropertyChangedEventHandler(rp_PropertyChanged);
                rp.Open(new Mp3Reader(File.OpenRead("in.mp3")));
                rp.Play();
                rp.Forward(1000);
                rp.Pause();
            }
            
            static void rp_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case RecordPlayer.StateProperty:
                        RecordPlayer rp = ((RecordPlayer)sender);
                        if (rp.State == DeviceState.Stopped)
                        {
                            rp.Close();
                        }
                        break;
                }
            }
