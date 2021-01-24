    public class UploadedFile
    {
        public string FileFullName { get; set; }
        public byte[] Data { get; set; }
    
        public UploadedFile(string filePath)
        {
            FileFullName = Path.GetFileName(Normalize(filePath));
            Data = File.ReadAllBytes(filePath);
        }
        private string Normalize(string input)
        {
            return new string(input
                    .Normalize(System.Text.NormalizationForm.FormD)
                    .Replace(" ", string.Empty)
                    .ToCharArray()
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray());
        }
    }
