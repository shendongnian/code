    using (IWavePlayer directOut = new DirectSoundOut(300))               
    {                    
       directOut.Init(blockAlignedStream);                    
       directOut.Play();                    
       while (blockAlignedStream.Position < blockAlignedStream.Length)
       {                       
          System.Threading.Thread.Sleep(100);                    
       }                
    }
