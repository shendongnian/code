    public async Task<ActionResult> Receipt(int year, int Id, ReceiptViewModel model)
    {
        ...
        await mailer.BulkReceipt(path, pdfname, Id, year).SendAsync();
        // Delete file
        System.IO.File.Delete(path);
        return View("ReceiptSuccess", a);
    }
