        public void optimizeImages()
        {
            string folder = 
                Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"assets\temp");
            var files = Directory.EnumerateFiles(folder);
            foreach (var file in files)
            {
                switch (Path.GetExtension(file).ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        optimizeJPEG(file);
                        break;
                    case ".png":
                        optimizePNG(file);
                        break;
                }
            }
        }
        private void optimizeJPEG(string file)
        {
            string pathToExe = HostingEnvironment.MapPath("~\\adminassets\\exe\\") + "jpegtran.exe";
            var proc = new Process
            {
                StartInfo =
                {
                    Arguments = "-optimize \"" + file + "\" \"" + file + "\"",
                    FileName = pathToExe,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };
            Process jpegTranProcess = proc;
            jpegTranProcess.Start();
            jpegTranProcess.WaitForExit();
        }
        private void optimizePNG(string file)
        {
            string tempFile = Path.GetDirectoryName(file) + @"\temp-" + Path.GetFileName(file);
            int alphaTransparency = 10;
            int alphaFader = 70;
            var quantizer = new WuQuantizer();
            using (var bitmap = new Bitmap(file))
            {
                using (var quantized = quantizer.QuantizeImage(bitmap, alphaTransparency, alphaFader))
                {
                    quantized.Save(tempFile, ImageFormat.Png);
                }
            }
            System.IO.File.Delete(file);
            System.IO.File.Move(tempFile, file);
        }
