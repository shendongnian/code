    public interface IApplicationData
    {
        string RootFolderName { get; }
        string ProductPictureFolder { get; }
        string ProductMainPictureFolder { get; }
        string WebRootPath { get; }
        string RootPath { get; }
        string GetProductPicturePath();
        string GetProductMainPicturePath();
        string GetNewPath();
    }
