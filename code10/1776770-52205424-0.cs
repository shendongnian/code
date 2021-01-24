    using SharpCifs.Smb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            networkImage = FindViewById<ImageView>(Resource.Id.imageViewNetwork);
            GetImageBitmapFromPath("smb://192.168.1.100/Media/Media/test.bmp");
        }
        private async void GetImageBitmapFromPath(string path)
        {
            byte[] imst = await LoadPic(path);
            Bitmap bmpa = BitmapFactory.DecodeByteArray(imst, 0, imst.Length);
            networkImage.SetImageBitmap(bmpa);            
        }
        private async Task<byte[]> LoadPic(string path)
        {
            var auth1 = new NtlmPasswordAuthentication("admin:admin");
            var imageFile = new SmbFile(path, auth1);
            var memStream = new MemoryStream();
            if (imageFile.Exists())
            {
                var readStream = imageFile.GetInputStream();
                ((Stream)readStream).CopyTo(memStream);
                
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }
  
  
