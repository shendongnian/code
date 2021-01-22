    public class Beep
    {
      public static void BeepBeep(int Amplitude, int Frequency, int Duration)
      {
        double A = ((Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1;
        double DeltaFT = 2 * Math.PI * Frequency / 44100.0;
    
        int Samples = 441 * Duration / 10;
        int Bytes = Samples * 4;
        int[] Hdr = {0X46464952, 36 + Bytes, 0X45564157, 0X20746D66, 16, 0X20001, 44100, 176400, 0X100004, 0X61746164, Bytes};
        using (MemoryStream MS = new MemoryStream(44 + Bytes))
        {
          using (BinaryWriter BW = new BinaryWriter(MS))
          {
            for (int I = 0; I < Hdr.Length; I++)
            {
              BW.Write(Hdr[I]);
            }
            for (int T = 0; T < Samples; T++)
            {
              short Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T));
              BW.Write(Sample);
              BW.Write(Sample);
            }
            BW.Flush();
            MS.Seek(0, SeekOrigin.Begin);
            using (SoundPlayer SP = new SoundPlayer(MS))
            {
              SP.PlaySync();
            }
          }
        }
      }
    }
