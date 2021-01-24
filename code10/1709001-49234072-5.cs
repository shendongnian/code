     public static void SaveAs(this IFormFile formFile, string filePath)
        {
            using (var stream = new FileStream( Path.Combine( filePath, formFile.FileName), FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
        }
