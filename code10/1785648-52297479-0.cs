    if (ModelState.IsValid)
    {
        var newRecordObj = new CWRecords
        {
            CWId = model.CWId,
            DateAdded = DateTime.Now,
        };
        using (var memoryStream = new MemoryStream())
        {
            await model.Document.CopyToAsync(memoryStream);
            newRecordObj.Document = memoryStream.ToArray();
        };
        _db.Add(newRecordObj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Create), new { CWId = model.CWId });
    }
