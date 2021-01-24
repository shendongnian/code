    using System;
    using System.Windows.Forms;
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    using static System.Environment;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            WaveFileWriter fileWriter;
            WaveOut outputSound;
            WaveIn waveSource;
            RawSourceWaveStream RSS;
            OffsetSampleProvider offsetSampleProvider;
            Stream sourceStream;
    
            string fileName = GetFolderPath(SpecialFolder.CommonApplicationData) + "\\temp.wav";
    
            public Form1()
            {
                InitializeComponent();
    
                outputSound = new WaveOut();
                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(8000, 16, 1);
                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                fileWriter = new WaveFileWriter(fileName, waveSource.WaveFormat);
                sourceStream = new MemoryStream();
    
                waveSource.StartRecording();
            }
    
            private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
            {
                fileWriter.Write(e.Buffer, 0, e.BytesRecorded);
                sourceStream.Write(e.Buffer, 0, e.BytesRecorded);
            }
    
            private void btnPlay_Click(object sender, EventArgs e)
            {
                RSS = new RawSourceWaveStream(sourceStream, waveSource.WaveFormat);
                RSS.Position = 0;
                offsetSampleProvider = new OffsetSampleProvider(RSS.ToSampleProvider());
                offsetSampleProvider.SkipOver = TimeSpan.FromMilliseconds(0);
                offsetSampleProvider.Take = TimeSpan.FromMilliseconds(3000);
                outputSound.Init(offsetSampleProvider);
                outputSound.Play();
            }
        }
    }
