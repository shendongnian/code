using (var ocr = new tessnet2.Tesseract())
{
    ocr.Init(null, "eng", false);
    ...
}
