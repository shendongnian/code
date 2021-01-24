    private async Task getImage(string imgUrl)
        {
            var  request = WebRequest.Create(imgUrl);
            using (var testing = await request.GetResponseAsync())
            {
                using (var str =  testing.GetResponseStream())
                {
                    addTablePic.Image = Image.FromStream(str);
                }
            }
        }
