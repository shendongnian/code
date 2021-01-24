           using (BrotliStream bs = new BrotliStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress)) {
                using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream()) {
                    bs.CopyTo(msOutput);
                    msOutput.Seek(0, System.IO.SeekOrigin.Begin);
                    using (StreamReader reader = new StreamReader(msOutput)) {
                        html = reader.ReadToEnd();
                    }
                }
            }
