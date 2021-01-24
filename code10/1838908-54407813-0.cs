    using Kofax.AscentCapture.NetScripting;
    using Kofax.Capture.CaptureModule.InteropServices;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    public class Save_Snippet : RecognitionScript {
    
        public Save_Snippet() : base()
        {
            this.BatchLoading += Save_Snippet_BatchLoading;
            this.BatchUnloading += Save_Snippet_BatchUnloading;
        }
            
    
        void Save_Snippet_BatchLoading(object sender, ref bool ImageFileRequired)
        {
            this.RecognitionPostProcessing += Save_Snippet_RecognitionPostProcessing;
            ImageFileRequired = true;
        }
    
    
        void Save_Snippet_BatchUnloading(object sender)
        {
            this.BatchLoading -= Save_Snippet_BatchLoading;
            this.RecognitionPostProcessing -= Save_Snippet_RecognitionPostProcessing;
            this.BatchUnloading -= Save_Snippet_BatchUnloading;
                
        }
    
    
        void Save_Snippet_RecognitionPostProcessing(object sender, PostRecognitionEventArgs e)
        {
            File.Copy(e.ImageFile, @"C:\temp\test.tiff");
        }
    
    }
