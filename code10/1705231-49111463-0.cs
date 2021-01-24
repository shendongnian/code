    static byte[] RenameFields(string src, int i, string imageName, string customer, string dateProc, string partFileName, string partFileLocation)
        {
            //This method creates a new document in memory with newly named unique fields
            MemoryStream baos = new MemoryStream();
            PdfReader reader = new PdfReader(src);
            PdfStamper stamper = new PdfStamper(reader, baos);
            stamper.Writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_7);
            stamper.AcroFields.GenerateAppearances = true;
            stamper.FormFlattening = false;
            AcroFields form = stamper.AcroFields;
            //Set Fields that don't need to be recreated
            form.SetField("tfCustomer", customer);
            form.SetField("tfDate", dateProc);
            form.SetField("tfFileName", partFileName);
            form.SetField("tfFileLocation", partFileLocation);
            form.SetField("tfQuantity", "300");
            form.SetField("tfLeadTime", "-");
            form.SetField("tfMaterialType", "N/A");
            form.SetField("tfThickness", "N/A");
            //Place Image
            string imageField = "ifPart";
            iTextSharp.text.Rectangle imageRect = form.GetFieldPositions(imageField)[0].position;
            Bitmap imageBitmap = new Bitmap(imageName);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageBitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            image.ScaleAbsolute(imageRect.Width, imageRect.Height);
            image.SetAbsolutePosition(imageRect.GetLeft(0), imageRect.GetBottom(0));
            PdfContentByte content = stamper.GetOverContent(1);
            content.AddImage(image);
            //populate names with the dictionary keys for the current file(stream)
            string[] names = new string[stamper.AcroFields.Fields.Keys.Count];
            stamper.AcroFields.Fields.Keys.CopyTo(names, 0);
            //rename all fields in this file(stream)
            foreach (string name in names)
            {
                stamper.AcroFields.RenameField(name, name + i);
            }
            //Add the calculation action to totalPrice(i)
            AcroFields.Item newTotalField = form.GetFieldItem("tfTotalPrice" + i);
            PdfDictionary newTotalRefDict = (PdfDictionary)PdfReader.GetPdfObject(newTotalField.GetWidgetRef(0));
            PdfString newTotalP = newTotalRefDict.GetAsString(PdfName.T);
            PdfArray totalRect = newTotalRefDict.GetAsArray(PdfName.RECT);
            AcroFields.Item newSetupField = stamper.AcroFields.GetFieldItem("tfSetupPrice" + i);
            PdfDictionary newSetupRefDict = (PdfDictionary)PdfReader.GetPdfObject(newSetupField.GetWidgetRef(0));
            PdfString newSetupP = newSetupRefDict.GetAsString(PdfName.T);
            PdfArray setupRect = newSetupRefDict.GetAsArray(PdfName.RECT);
            AcroFields.Item newToolField = stamper.AcroFields.GetFieldItem("tfToolPrice" + i);
            PdfDictionary newToolRefDict = (PdfDictionary)PdfReader.GetPdfObject(newToolField.GetWidgetRef(0));
            PdfString newToolP = newToolRefDict.GetAsString(PdfName.T);
            PdfArray toolRect = newToolRefDict.GetAsArray(PdfName.RECT);
            AcroFields.Item newPieceField = stamper.AcroFields.GetFieldItem("tfPiecePrice" + i);
            PdfDictionary newPieceRefDict = (PdfDictionary)PdfReader.GetPdfObject(newPieceField.GetWidgetRef(0));
            PdfString newPieceP = newPieceRefDict.GetAsString(PdfName.T);
            PdfArray pieceRect = newPieceRefDict.GetAsArray(PdfName.RECT);
            AcroFields.Item newFixtureField = stamper.AcroFields.GetFieldItem("tfFixturePrice" + i);
            PdfDictionary newFixtureRefDict = (PdfDictionary)PdfReader.GetPdfObject(newFixtureField.GetWidgetRef(0));
            PdfString newFixtureP = newFixtureRefDict.GetAsString(PdfName.T);
            PdfArray fixtureRect = newFixtureRefDict.GetAsArray(PdfName.RECT);
            //PiecePrice Field
            var llxPiece = Convert.ToDecimal(pieceRect[0].ToString());
            var llyPiece = Convert.ToDecimal(pieceRect[1].ToString());
            var urxPiece = Convert.ToDecimal(pieceRect[2].ToString());
            var uryPiece = Convert.ToDecimal(pieceRect[3].ToString());
            //Remove Old Price Field
            form.RemoveField(newPieceP.ToString());
            //In with the new
            TextField PieceField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle((float)llxPiece, (float)llyPiece, (float)urxPiece, (float)uryPiece), newPieceP.ToString())
            {
                Alignment = 1,
                Text = "0.00"
            };
            PdfFormField fPiece = PieceField.GetTextField();
            fPiece.SetAdditionalActions(PdfName.BL, PdfAction.JavaScript("this.getField('" + newTotalP + "').value = (parseFloat(this.getField('" + newPieceP + "').value) + parseFloat(this.getField('" + newToolP + "').value) + parseFloat(this.getField('" + newFixtureP + "').value) + parseFloat(this.getField('" + newSetupP + "').value));", stamper.Writer));
            fPiece.SetAdditionalActions(PdfName.F, PdfAction.JavaScript("AFNumber_Format(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            fPiece.SetAdditionalActions(PdfName.K, PdfAction.JavaScript("AFNumber_Keystroke(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            stamper.AddAnnotation(fPiece, 1);
            //ToolPrice Field
            var llxTool = Convert.ToDecimal(toolRect[0].ToString());
            var llyTool = Convert.ToDecimal(toolRect[1].ToString());
            var urxTool = Convert.ToDecimal(toolRect[2].ToString());
            var uryTool = Convert.ToDecimal(toolRect[3].ToString());
            //Remove Old Price Field
            form.RemoveField(newToolP.ToString());
            //In with the new
            TextField ToolField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle((float)llxTool, (float)llyTool, (float)urxTool, (float)uryTool), newToolP.ToString())
            {
                Alignment = 1,
                Text = "0.00"
            };
            PdfFormField fTool = ToolField.GetTextField();
            fTool.SetAdditionalActions(PdfName.BL, PdfAction.JavaScript("this.getField('" + newTotalP + "').value = (parseFloat(this.getField('" + newPieceP + "').value) + parseFloat(this.getField('" + newToolP + "').value) + parseFloat(this.getField('" + newFixtureP + "').value) + parseFloat(this.getField('" + newSetupP + "').value));", stamper.Writer));
            fTool.SetAdditionalActions(PdfName.F, PdfAction.JavaScript("AFNumber_Format(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            fTool.SetAdditionalActions(PdfName.K, PdfAction.JavaScript("AFNumber_Keystroke(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            stamper.AddAnnotation(fTool, 1);
            //FixturePrice Field
            var llxFixture = Convert.ToDecimal(fixtureRect[0].ToString());
            var llyFixture = Convert.ToDecimal(fixtureRect[1].ToString());
            var urxFixture = Convert.ToDecimal(fixtureRect[2].ToString());
            var uryFixture = Convert.ToDecimal(fixtureRect[3].ToString());
            //Remove Old Price Field
            form.RemoveField(newFixtureP.ToString());
            //In with the new
            TextField FixtureField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle((float)llxFixture, (float)llyFixture, (float)urxFixture, (float)uryFixture), newFixtureP.ToString())
            {
                Alignment = 1,
                Text = "0.00"
            };
            PdfFormField fFixture = FixtureField.GetTextField();
            fFixture.SetAdditionalActions(PdfName.BL, PdfAction.JavaScript("this.getField('" + newTotalP + "').value = (parseFloat(this.getField('" + newPieceP + "').value) + parseFloat(this.getField('" + newToolP + "').value) + parseFloat(this.getField('" + newFixtureP + "').value) + parseFloat(this.getField('" + newSetupP + "').value));", stamper.Writer));
            fFixture.SetAdditionalActions(PdfName.F, PdfAction.JavaScript("AFNumber_Format(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            fFixture.SetAdditionalActions(PdfName.K, PdfAction.JavaScript("AFNumber_Keystroke(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            stamper.AddAnnotation(fFixture, 1);
            //SetupPrice Field
            var llxSetup = Convert.ToDecimal(setupRect[0].ToString());
            var llySetup = Convert.ToDecimal(setupRect[1].ToString());
            var urxSetup = Convert.ToDecimal(setupRect[2].ToString());
            var urySetup = Convert.ToDecimal(setupRect[3].ToString());
            //Remove Old Price Field
            form.RemoveField(newSetupP.ToString());
            //In with the new
            TextField setupField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle((float)llxSetup, (float)llySetup, (float)urxSetup, (float)urySetup), newSetupP.ToString())
            {
                Alignment = 1,
                Text = "0.00"
            };
            PdfFormField fSetup = setupField.GetTextField();
            fSetup.SetAdditionalActions(PdfName.BL, PdfAction.JavaScript("this.getField('" + newTotalP + "').value = (parseFloat(this.getField('" + newPieceP + "').value) + parseFloat(this.getField('" + newToolP + "').value) + parseFloat(this.getField('" + newFixtureP + "').value) + parseFloat(this.getField('" + newSetupP + "').value));", stamper.Writer));
            fSetup.SetAdditionalActions(PdfName.F, PdfAction.JavaScript("AFNumber_Format(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            fSetup.SetAdditionalActions(PdfName.K, PdfAction.JavaScript("AFNumber_Keystroke(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            stamper.AddAnnotation(fSetup, 1);
            var llxTotal = Convert.ToDecimal(totalRect[0].ToString());
            var llyTotal = Convert.ToDecimal(totalRect[1].ToString());
            var urxTotal = Convert.ToDecimal(totalRect[2].ToString());
            var uryTotal = Convert.ToDecimal(totalRect[3].ToString());
            form.RemoveField(newTotalP.ToString());
            TextField TotalField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle((float)llxTotal, (float)llyTotal, (float)urxTotal, (float)uryTotal), newTotalP.ToString())
            {
                Alignment = 1
            };
            PdfFormField fTotal = TotalField.GetTextField();
            fTotal.SetAdditionalActions(PdfName.BL, PdfAction.JavaScript("this.getField('" + newTotalP + "').value = (parseFloat(this.getField('" + newPieceP + "').value) + parseFloat(this.getField('" + newToolP + "').value) + parseFloat(this.getField('" + newFixtureP + "').value) + parseFloat(this.getField('" + newSetupP + "').value));", stamper.Writer));
            fTotal.SetAdditionalActions(PdfName.F, PdfAction.JavaScript("AFNumber_Format(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            fTotal.SetAdditionalActions(PdfName.K, PdfAction.JavaScript("AFNumber_Keystroke(2, 0, 0, 0, '\u0024', true);", stamper.Writer));
            stamper.AddAnnotation(fTotal, 1);
            stamper.AcroFields.GenerateAppearances = true;
            //close up shop and return the new doc in memory
            stamper.Close();
            reader.Close();
            return baos.ToArray();
        }
