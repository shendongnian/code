        public static int GetSoundLength(string fileName)
         {
            using (WaveFileReader wf = new WaveFileReader(fileName))
            {
                return (int)wf.TotalTime.TotalMilliseconds;
            }
         }`
 
