    public async Task<JsonResult> DeleteImages(List<string> ids)
    {
        var files = new FileCollection();
        foreach (var id in ids)
        {
            var file = await _fileService.GetByIdAsync(id);
            if (await AzureStorage.DeleteFile(file))
            {
                files.Files.Add(new Dictionary<string, bool> { { file.Name, true } });
            }
        }
        return Json(JsonConvert.SerializeObject(files));
    }
