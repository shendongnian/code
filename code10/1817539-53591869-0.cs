     public async Task<Image> GetAvatar(string dpi, Int64 uin)
            {
                var response = await BasicRequestAsync(string.Format(AVATAR_URL, dpi, uin), HttpMethod.Get, true, null, null, false);
    
                if(response == null) return null;
    
                var stream = await response.Content.ReadAsByteArrayAsync();
    
                Image image = new Image();
    
                image.Source = ImageSource.FromStream(() => new MemoryStream(stream));
    
                return image;
            }
