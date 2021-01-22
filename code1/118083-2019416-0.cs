      var document = new Document();
      PdfWriter pdfWriter = PdfWriter.GetInstance(
        document, new FileStream(destinationFile, FileMode.Create)
      );
      pdfWriter.SetFullCompression();
      pdfWriter.StrictImageSequence = true;
      pdfWriter.SetLinearPageMode();           
