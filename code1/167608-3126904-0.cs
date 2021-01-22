    public delegate void FileUploadSuccess<T>(T value, FileUploadType F)
    public class FileUploader<T>
    {
        public event FileUploadSuccess<T> FileUploaded;
    }
