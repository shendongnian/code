    using NAudio.Wave;
    using System;
    
    namespace NAudioSegments
    {
        class SegmentProvider : IWaveProvider
        {
            private readonly WaveStream sourceStream;
            private int segmentStart, segmentDuration;
    
            public SegmentProvider(WaveStream sourceStream)
            {
                this.sourceStream = sourceStream;
            }
    
            public WaveFormat WaveFormat => sourceStream.WaveFormat;
    
            public void DefineSegment(TimeSpan start, TimeSpan duration)
            {
                if (start + duration > sourceStream.TotalTime)
                    throw new ArgumentOutOfRangeException("Segment goes beyond end of input");
                segmentStart = TimeSpanToOffset(start);
                segmentDuration = TimeSpanToOffset(duration);
                sourceStream.Position = segmentStart;
            }
    
            public int TimeSpanToOffset(TimeSpan ts)
            {
                var bytes = (int)(WaveFormat.AverageBytesPerSecond * ts.TotalSeconds);
                bytes -= (bytes % WaveFormat.BlockAlign);
                return bytes;
            }
    
            public int Read(byte[] buffer, int offset, int count)
            {
                int totalBytesRead = 0;
                int bytesRead = 0;
                do
                {
                    bytesRead = ReadFromSegment(buffer, offset + totalBytesRead, count - totalBytesRead);
                    totalBytesRead += bytesRead;
                } while (totalBytesRead < count && bytesRead != 0);
                return totalBytesRead;
            }
    
            private int ReadFromSegment(byte[] buffer, int offset, int count)
            {
                var bytesAvailable = (int)(segmentStart + segmentDuration - sourceStream.Position);
                var bytesRequired = Math.Min(bytesAvailable, count);
                return sourceStream.Read(buffer, offset, bytesRequired);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var source = new Mp3FileReader(@"<input-path>"))
                {
                    var segmentProvider = new SegmentProvider(source);
                    // Add desired splitting e.g. start at 2 seconds, duration 1 second
                    segmentProvider.DefineSegment(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1));
                    WaveFileWriter.CreateWaveFile(@"<output-path>", segmentProvider);
                }
            }
        }
    }
