    public class DocumentMerger
    {
        private readonly WordprocessingDocument _targetDocument;
    
        public DocumentMerger(WordprocessingDocument targetDocument)
        {
            this._targetDocument = targetDocument;
        }    
        
        public void Merge(WordprocessingDocument sourceDocument)
        {
            ImagesMerger imagesMerger = new ImagesMerger(this._targetDocument);
            this._imagesMerger.Merge(sourceDocument);
            
            // Merge the content; paragraphs and tables.
            this._targetDocumentPart.Document.Save();
        }    
    }
    public class ImageInfo
    {
        private String _id;
        private ImagePart _image;
        private readonly String _originalId;
    
        private ImageInfo(ImagePart image, String id)
        {  
            this._id = id;
            this._image = image;
            this._originalId = id;
        }
        
        public String Id 
        { 
            get { return this._id; } 
        }
    
        public ImagePart Image
        {
            get { return this._image; }
        }
            
        public String OriginalId
        {
            get { return this._originalId; }
        }
    
        public static ImageInfo Create(MainDocumentPart documentPart, ImagePart image)
        {
            String id = documentPart.GetIdOfPart(image);
            ImageInfo r = new ImageInfo(image, id);
            return r;
        }    
             
        public void Reparent(MainDocumentPart documentPart)
        {   
            ImagePart newImage = documentPart.AddImagePart(this._image.ContentType);                
            newImage.FeedData(this._image.GetStream(FileMode.Open, FileAccess.Read));
            String newId = documentPart.GetIdOfPart(newImage);                        
            this._id = newId;
            this._image = newImage;                
        }    
    }
    public class ImagesMerger 
    {
        private readonly IList<ImageInfo> _imageInfosOfTheTargetDocument = new List<ImageInfo>();        
        private readonly MainDocumentPart _targetDocumentPart;
    
        public ImagesMerger(WordprocessingDocument targetDocument)
        {
            this._targetDocumentPart = targetDocument.MainDocumentPart;
        }
        
        public void Merge(WordprocessingDocument sourceDocument)
        {
            MainDocumentPart sourceDocumentPart = sourceDocument.MainDocumentPart;
            IList<ImageInfo> imageInfosOfTheSourceDocument = this.getImageInfos(sourceDocumentPart);
            if (0 == imageInfosOfTheSourceDocument.Count) { return; }
                
            this.addTheImagesToTheTargetDocument(imageInfosOfTheSourceDocument);
            this.rereferenceTheImagesToTheirCorrespondingImageParts(sourceDocumentPart, imageInfosOfTheSourceDocument);
        }
    
        private void addTheImagesToTheTargetDocument(IList<ImageInfo> imageInfosOfTheSourceDocument)
        {
            for (Int32 i = 0, j = imageInfosOfTheSourceDocument.Count; i < j; i++)
            {
                imageInfoOfTheSourceDocument.Reparent(this._targetDocumentPart);
                this._imageInfosOfTheTargetDocument.Add(imageInfoOfTheSourceDocument);                    
            }            
        }
        
        private IList<ImageInfo> getImageInfos(MainDocumentPart documentPart)
        {
            List<ImageInfo> r = new List<ImageInfo>();
            
            foreach (ImagePart image in documentPart.ImageParts)
            {
                ImageInfo imageInfo = ImageInfo.Create(documentPart, image);
                r.Add(imageInfo);
            }
            
            return r;
        }
      
        private void rereferenceTheImagesToTheirCorrespondingImageParts(MainDocumentPart sourceDocumentPart, IList<ImageInfo> imageInfosOfTheSourceDocument)
        {
            IEnumerable<Drawing> images = sourceDocumentPart.Document.Body.Descendants<Drawing>();
    
            foreach (Drawing image in images)
            {
                Blip blip = image.Inline.Graphic.GraphicData.Descendants<Blip>().FirstOrDefault();
                String originalId = blip.Embed.Value;
                                
                ImageInfo imageInfo = imageInfosOfTheSourceDocument.FirstOrDefault(o => o.OriginalId._Equals(originalId));
                blip.Embed.Value = imageInfo.Id;
            }
        }
    }
