    public void UploadProductImage(string SKU, string path)
            {
                var imageStream = new MemoryStream();
    
                using (var i = Image.FromFile(@"c:\ProductImages\" + path))   
                {
                           i.Save(imageStream, ImageFormat.Jpeg);
                }
                    byte[] encbuff = imageStream.ToArray(); 
                
                string enc = Convert.ToBase64String(encbuff,0 , encbuff.Length);
    
    
                var imageEntity = new catalogProductImageFileEntity();
                imageEntity.content = enc;
                imageEntity.mime = "image/jpeg";
                imageStream.Close();
    
                var entityP = new catalogProductAttributeMediaCreateEntity();
                entityP.file = imageEntity;
                entityP.types = new[] {"image", "small_image", "thumbnail"};
                entityP.position = "0";
                entityP.exclude = "0";
    
                _m.catalogProductAttributeMediaCreate(MageSessionProvider.GetSession(), SKU, entityP, "default");
                Console.WriteLine("Image Uploaded");
            }
