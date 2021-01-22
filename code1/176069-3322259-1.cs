    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Validation;
    using DocumentFormat.OpenXml.Wordprocessing;
    using OVML = DocumentFormat.OpenXml.Vml.Office;
    using V = DocumentFormat.OpenXml.Vml;
    public class OpenXmlHelper
    {
        /// <summary>
        /// Appends an Embedded Object into the specified Main Document
        /// </summary>
        /// <param name="mainDocumentPart">The MainDocument Part of your OpenXml Word Doc</param>
        /// <param name="fileInfo">The FileInfo object associated with the file being embedded</param>
        /// <param name="displayAsIcon">Whether or not to display the embedded file as an Icon (Otherwise it will display a snapshot of the file)</param>
        public static void AppendEmbeddedObject(MainDocumentPart mainDocumentPart, FileInfo fileInfo, bool displayAsIcon)
        {
            OpenXmlEmbeddedObject openXmlEmbeddedObject = new OpenXmlEmbeddedObject(fileInfo, displayAsIcon);
            if (!String.IsNullOrEmpty(openXmlEmbeddedObject.OleObjectBinaryData))
            {
                using (Stream dataStream = new MemoryStream(Convert.FromBase64String(openXmlEmbeddedObject.OleObjectBinaryData)))
                {
                    if (!String.IsNullOrEmpty(openXmlEmbeddedObject.OleImageBinaryData))
                    {
                        using (Stream emfStream = new MemoryStream(Convert.FromBase64String(openXmlEmbeddedObject.OleImageBinaryData)))
                        {
                            string imagePartId = OpenXmlWordHelper.GetUniqueXmlItemID();
                            ImagePart imagePart = mainDocumentPart.AddImagePart(ImagePartType.Emf, imagePartId);
                            if (emfStream != null)
                            {
                                imagePart.FeedData(emfStream);
                            }
                            string embeddedPackagePartId = OpenXmlWordHelper.GetUniqueXmlItemID();
                            if (dataStream != null)
                            {
                                if (openXmlEmbeddedObject.ObjectIsOfficeDocument)
                                {
                                    EmbeddedPackagePart embeddedObjectPart = mainDocumentPart.AddNewPart<EmbeddedPackagePart>(
                                        openXmlEmbeddedObject.FileContentType, embeddedPackagePartId);
                                    embeddedObjectPart.FeedData(dataStream);
                                }
                                else
                                {
                                    EmbeddedObjectPart embeddedObjectPart = mainDocumentPart.AddNewPart<EmbeddedObjectPart>(
                                        openXmlEmbeddedObject.FileContentType, embeddedPackagePartId);
                                    embeddedObjectPart.FeedData(dataStream);
                                }
                            }
                            if (!displayAsIcon && !openXmlEmbeddedObject.ObjectIsPicture)
                            {
                                Paragraph attachmentHeader = OpenXmlWordHelper.CreateParagraph(JustificationValues.Left,
                                    OpenXmlWordHelper.ParagraphSpacing.AfterMedium, null, true, false,
                                    String.Format("Attachment: {0} (Double-Click to Open)", fileInfo.Name));
                                mainDocumentPart.Document.Body.Append(attachmentHeader);
                            }
                            Paragraph embeddedObjectParagraph = GetEmbeededObjectParagraph(openXmlEmbeddedObject.FileType,
                                imagePartId, openXmlEmbeddedObject.OleImageStyle, embeddedPackagePartId);
                            mainDocumentPart.Document.Body.Append(embeddedObjectParagraph);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets Paragraph that includes the embedded object
        /// </summary>
        private static Paragraph GetEmbeededObjectParagraph(string fileType, string imageID, string imageStyle, string embeddedPackageID)
        {
            EmbeddedObject embeddedObject = new EmbeddedObject();
            string shapeID = GetUniqueXmlItemID();
            V.Shape shape = new V.Shape() { Id = shapeID, Style = imageStyle };
            V.ImageData imageData = new V.ImageData() { Title = "", RelationshipId = imageID };
            shape.Append(imageData);
            OVML.OleObject oleObject = new OVML.OleObject()
            {
                Type = OVML.OleValues.Embed,
                ProgId = fileType,
                ShapeId = shapeID,
                DrawAspect = OVML.OleDrawAspectValues.Icon,
                ObjectId = GetUniqueXmlItemID(),
                Id = embeddedPackageID
            };
            embeddedObject.Append(shape);
            embeddedObject.Append(oleObject);
            Paragraph paragraphImage = new Paragraph();
            Run runImage = new Run(embeddedObject);
            paragraphImage.Append(runImage);
            return paragraphImage;
        }
        /// <summary>
        /// Gets a Unique ID for an XML Item, for reference purposes
        /// </summary>
        /// <returns>A GUID string with removed dashes</returns>
        public static string GetUniqueXmlItemID()
        {
            return "r" + System.Guid.NewGuid().ToString().Replace("-", "");
        }
    }
