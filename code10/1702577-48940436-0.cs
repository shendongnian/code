            private static void FindAndReplaceImages(Document wordDoc, string imagePath){
            var sec = wordDoc.Application.Selection.Sections[1];
            
            foreach (Section wordSection in wordDoc.Sections)
            {
                var footer = sec.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                var footerImage = footer.Shapes.AddShape(1, 0, 0, 594, 280);
                footerImage.Fill.UserPicture(imagePath);
                footerImage.WrapFormat.Type = WdWrapType.wdWrapThrough;
                footerImage.WrapFormat.AllowOverlap = -1;
                footerImage.WrapFormat.Side = WdWrapSideType.wdWrapBoth;
                footerImage.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage;
                footerImage.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionPage;
                footerImage.Top = (float)561.2;
            }
        }
