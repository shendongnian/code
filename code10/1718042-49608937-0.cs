         On Server Side
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NAudio.Wave;
    
    namespace NaudioVoiceChat
    {
        public partial class Server: Form
        {
            #region Codes for NAudio ------->>>> This is for NAudio
            private BufferedWaveProvider bwp;
            WaveIn wi;
            WaveOut wo;
            
            #endregion 
    
    
            public Server()
            {
                InitializeComponent();
    
                #region Code for Naudio
                wo = new WaveOut();
                wi = new WaveIn();
    
                wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
    
                bwp = new BufferedWaveProvider(wi.WaveFormat);
                bwp.DiscardOnBufferOverflow = true;
    
                wo.Init(bwp);
                wi.StartRecording();
               
               
            
                #endregion
    
    
            }
    
            private void Server_Load(object sender, EventArgs e)
            {
    
            }
    
    
            void wi_DataAvailable(object sender, WaveInEventArgs e)
            {
                bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
                server.SendData("Client-1", e.Buffer);
            }
