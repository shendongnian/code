    class Program
    {
        static void Main(string[] args)
        {
            using (var stitch = new StitchEngineWrapper()) // using Microsoft.Research.ICE.Stitching;
            {
                var taskCompleted = new AutoResetEvent(false);
                stitch.ProgressChanged += (s, e) => Console.Write(".");
                stitch.TaskCompleted += (s, e) =>
                {
                    Console.WriteLine();
                    taskCompleted.Set();
                };
                var pi = new StitchProjectInfo();
                pi.SourceImages.Add(new ImageInfo(@"c:\myPath\lenna1.jpg", null));
                pi.SourceImages.Add(new ImageInfo(@"c:\myPath\lenna2.jpg", null));
                if (!stitch.InitializeFromProjectInfo(pi) || stitch.HasLastError)
                {
                    Console.WriteLine("Initialization failed.");
                    if (stitch.HasLastError)
                    {
                        Console.WriteLine("Error 0x" + stitch.LastError.ToString("x8") + ": " + stitch.LastErrorMessage);
                    }
                    return;
                }
                Console.WriteLine("Initialization ok.");
                stitch.StartAligning();
                taskCompleted.WaitOne(Timeout.Infinite);
                if (stitch.AlignedCount < 2 || stitch.HasLastError)
                {
                    Console.WriteLine("Alignement failed. Wrong input.");
                    Console.WriteLine("Error 0x" + stitch.LastError.ToString("x8") + ": " + stitch.LastErrorMessage);
                    return;
                }
                Console.WriteLine("Alignement ok.");
                stitch.StartCompositing();
                taskCompleted.WaitOne(Timeout.Infinite);
                if (stitch.HasLastError)
                {
                    Console.WriteLine("Composition failed.");
                    Console.WriteLine("Error 0x" + stitch.LastError.ToString("x8") + ": " + stitch.LastErrorMessage);
                    return;
                }
                Console.WriteLine("Composition ok.");
                stitch.StartProjecting();
                taskCompleted.WaitOne(Timeout.Infinite);
                if (stitch.HasLastError)
                {
                    Console.WriteLine("Projection failed.");
                    Console.WriteLine("Error 0x" + stitch.LastError.ToString("x8") + ": " + stitch.LastErrorMessage);
                    return;
                }
                Console.WriteLine("Projection ok.");
                var options = new OutputOptions(ExportFormat.JPEG, 75, true, false, false);
                stitch.StartExporting(@"c:\myPath\stitched.jpg", stitch.ResetCropRect, 1, options, false);
                taskCompleted.WaitOne(Timeout.Infinite);
                Console.WriteLine("Export ok.");
            }
        }
    }
