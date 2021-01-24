    var file = await bot.GetFileAsync(update.Message.Photo.LastOrDefault()?.FileId);
    var jpgFileName = file.FileId + ".jpg";
    using (var saveImageStream = System.IO.File.Open(jpgFileName,FileMode.Create))
    {
        await bot.DownloadFileAsync(file.FilePath, saveImageStream);
        await bot.SendTextMessageAsync(update.Message.Chat.Id, "please wait...");
    }
    var webpFileName = file.FileId + ".webp";
    using (Bitmap bitmap = new Bitmap(jpgFileName))
    {
        using (var saveImageStream = System.IO.File.Open(webpFileName, FileMode.Create))
        {
            var encoder = new SimpleEncoder();
            encoder.Encode(bitmap, saveImageStream, 20);
        }
    }
    using (var stream = System.IO.File.Open(webpFileName, FileMode.Open))
    {
        await bot.SendStickerAsync(update.Message.Chat.Id, stream);
    }
    System.IO.File.Delete(jpgFileName);
    System.IO.File.Delete(webpFileName);
