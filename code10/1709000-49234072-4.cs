     public static void SaveAs(this IFormFile formFile, string filePath)
    {
        using (var stream = new FileStream( filePath, FileMode.Create))
        {
            formFile.CopyTo(stream);
        }
    }
