        [HttpGet]
        [Route("testfile")]
        public ActionResult TestFile()
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);
            tw.WriteLine("Hello World");
            tw.Flush();
            
            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);
            return File(toWrite, "text/plain", "file.txt");
        }
