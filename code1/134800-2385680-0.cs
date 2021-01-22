    private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                axQTControl1.URL = ofd.FileName;
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassAudio,
                    QTEventIDsEnum.qtEventAudioBalanceDidChange, null, null);
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassTemporal,
                    QTEventIDsEnum.qtEventTimeWillChange, null, null);
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassAudio,
                    QTEventIDsEnum.qtEventAudioVolumeDidChange, null, null);
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassApplicationRequest,
                    QTEventIDsEnum.qtEventAudioBalanceDidChange, null, null);
                axQTControl1.Movie.EventListeners.Add(QTOLibrary.QTEventClassesEnum.qtEventClassProgress, 
                    QTOLibrary.QTEventIDsEnum.qtEventExportProgress, null, null);
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassStateChange,
                    QTEventIDsEnum.qtEventMovieDidEnd, null, null);
                axQTControl1.Movie.EventListeners.Add(QTEventClassesEnum.qtEventClassStateChange,
                    QTEventIDsEnum.qtEventRateWillChange, null,  null);                                               
                                                    
            }
        }
        private void axQTControl1_QTEvent(object sender, AxQTOControlLib._IQTControlEvents_QTEventEvent e)
        {
            Console.WriteLine(e.eventID.ToString());
        }
       
