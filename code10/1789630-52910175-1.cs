        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            var buf = new byte[1024 * 64];
            long totalBytes = 0;
            using (var rs = Request.Body)
            {
                while (1 == 1)
                {
                    int bytesRead = await rs.ReadAsync(buf, 0, buf.Length);
                    if (bytesRead == 0) break;
                    totalBytes += bytesRead;
                }
            }
            var uploadedData = new
            {
                BytesRead = totalBytes
            };
            return new JsonResult(uploadedData) ;
        }
