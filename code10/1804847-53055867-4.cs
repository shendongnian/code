    private readonly IFileStreamProvider disk; //populated via constructor injection.
    public async Task<Result> SaveFileToDiskAsync(string filePath, IFormFile file, CancellationToken token) {
        //Checking if values are correct
        try {
            using (var stream = disk.Create(filePath)) {
                await file.CopyToAsync(stream, token).ConfigureAwait(false);
                return Result.Ok();
            }               
        } catch (Exception e) {
            //Logging
        }
    }
