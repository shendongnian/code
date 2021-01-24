    public class Request()
    {
        public async Task<Bitmap> GetImage(string url)
        {
            using (var client = new Url(url)
            {
                //return as image
                var content = await Task.Run(() => client.GetStringAsync());
            }
        }
    }
