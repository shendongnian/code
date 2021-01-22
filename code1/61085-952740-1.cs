    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            string RootPath = "C:\\";
            string savedFile = "test.avi";
            string inputPath = Path.Combine(RootPath, "videoinput");
            string ffmpegpath = Path.Combine(RootPath, "ffmpeg.exe"); //ffmpeg path
            string outputPath = Path.Combine(RootPath, "videooutput");
            //define new extension
            string fileext = ".flv";
            string namenoextension = Path.GetFileNameWithoutExtension(savedFile);
            string newfilename = namenoextension + fileext;
            string fileoutPath = Path.Combine(outputPath, newfilename);
            string fileinPath = Path.Combine(inputPath, savedFile);
            string arguments = string.Format("-i \"{0}\" -ar 44100 -ab 160k \"{1}\"", fileinPath, fileoutPath);
            Console.WriteLine(ffmpegpath);
            Console.WriteLine(arguments);
            Console.ReadKey();
        }
    }
