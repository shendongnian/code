            using (var ms = new MemoryStream())
            {
                var original = File.OpenRead("withoutlink.pptx");
                original.CopyTo(ms);
                using (var ppt = PresentationDocument.Open(ms, true))
                {
                    var slidePart1 = ppt.PresentationPart.SlideParts.First();
                    var slide1 = slidePart1.Slide;
                    var commonSlideData1 = slide1.GetFirstChild<CommonSlideData>();
                    var shapeTree1 = commonSlideData1.GetFirstChild<ShapeTree>();
                    var picture1 = shapeTree1.GetFirstChild<Picture>();
                    var nonVisualPictureProperties1 = picture1.GetFirstChild<NonVisualPictureProperties>();
                    var nonVisualDrawingProperties1 =
                        nonVisualPictureProperties1.GetFirstChild<NonVisualDrawingProperties>();
                    var nonVisualDrawingPropertiesExtensionList1 = nonVisualDrawingProperties1
                        .GetFirstChild<A.NonVisualDrawingPropertiesExtensionList>();
                    var relationshipId = "rId" + nonVisualPictureProperties1.Count();
                    var hyperlinkOnClick1 = new A.HyperlinkOnClick {Id = relationshipId};
                    nonVisualDrawingProperties1.InsertBefore(hyperlinkOnClick1,
                        nonVisualDrawingPropertiesExtensionList1);
                    slidePart1.AddHyperlinkRelationship(new Uri("http://www.google.com/", UriKind.Absolute), true,
                        relationshipId);
                    ppt.SaveAs("withlink.pptx");
                }
