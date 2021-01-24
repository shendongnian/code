    public static Bitmap ImageToTreat {
        set
        {
            ValeurPixelsExperiment = new double[value.Width];
            ImageToTreat = value;
        }
    }
    public double[] ValeurPixelsExperiment;
