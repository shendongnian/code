    class DataFromBitmap
    {
        static public Bitmap ImageToTreat; 
        double[] ValeurPixelsExperiment;
        double[] ValeurPixelsReference;
        double[] ValeurPixelsSumExperiment;
        double[] ValeurPixelsSumReference;
        int[] PixelColorCount;
        int[] PixelColorCountReady;
    
        /// <summary>
        /// Retrieves data from an input bitmap. Retrieved data : Ref and Exp pixel column mean values and count of each color level population. Output : double[1024] under ExpOutput() and RefOutput(), and int[256] under ColorCountOutput
        /// </summary>
        /// <param Bitmap to treat="pImageToTreat"></param>
        public DataFromBitmap(Bitmap pImageToTreat)
        {
            ValeurPixelsSumExperiment = new double[pImageToTreat.Width];
            ...
