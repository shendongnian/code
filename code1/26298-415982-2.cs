    using System;
    using System.IO;
    class Test
    {
        public static void Main()
        {
            string resumeFile = @"c:\ResumesArchive\923823.txt";
            string newFile = @"c:\ResumesImport\newResume.txt";
            if (File.Exists(resumeFile))
            {
                File.Copy(resumeFile, newFile);
            }
            else
            {
                Console.WriteLine("Resume file does not exist.");
            }
        }
    }
