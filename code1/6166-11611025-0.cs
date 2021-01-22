    public static void Main(String[] args)
    {
        string filename = args[0];
        using (FileStream fs = File.OpenRead(filename)) {
            Ude.CharsetDetector cdet = new Ude.CharsetDetector();
            cdet.Feed(fs);
            cdet.DataEnd();
            if (cdet.Charset != null) {
                Console.WriteLine("Charset: {0}, confidence: {1}", 
                     cdet.Charset, cdet.Confidence);
            } else {
                Console.WriteLine("Detection failed.");
            }
        }
    }    
