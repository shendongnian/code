            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            newBMP.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            
            PHJProjectPhoto myPhoto =
                new PHJProjectPhoto
                {
                    ProjectPhoto = stream.ToArray(), // <<--- This will convert your stream to a byte[]
                    OrderDate = DateTime.Now,
                    ProjectPhotoCaption = ProjectPhotoCaptionTextBox.Text,
                    ProjectId = selectedProjectId
                };
