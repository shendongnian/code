    public static void ShrinkVideo(string pathToVideo,int desiredMbSize,string outFile)
    {
         ProcessStartInfo psi = new ProcessStartInfo("ffmpeg.exe");
         psi.Arguments = string.Format("-i \"{0}\" -fs {1}M \"{2}\"",pathToVideo,desiredMbSize,outFile);
         Process proc = new Process(psi);
         proc.Start();
    }
