    public IActionResult IndexPost(IFormFile file)
            {
                Stream st =  file.OpenReadStream();
                MemoryStream mst = new MemoryStream();
                st.CopyTo(mst);            
                return Content(ToMD5Hash(mst.ToArray()));
            }       
    
            public static string ToMD5Hash(byte[] bytes)
            {
                if (bytes == null || bytes.Length == 0)
                    return null;
    
                using (var md5 = MD5.Create())
                {
                    return string.Join("", md5.ComputeHash(bytes).Select(x => x.ToString("X2")));
                }
            }
