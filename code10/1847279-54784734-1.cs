       public class RetrieveDataClass
       {
       
         public RetrieveDataClass()
         {
           AddBlog();
         }
      public class BlogViews
        {
            public string id { get; set; }
            public string DisplayTopic { get; set; }
            public string DisplayMain { get; set; }
            public ImageSource BlogImageSource { get; set; }
        }
        public List<BlogViews> BlogList1 = new List<BlogViews>();
        public async Task< List<BlogViews>> GetBlogs()
        {
            BlogRestClient<BlogViews> restClient = new BlogRestClient<BlogViews>();
            var BlogV = await restClient.GetAsync();
            return BlogV;
        }
        public async void AddBlog()
        {
            BlogList1 = await GetBlogs();
            BlogListView.ItemsSource = BlogList1;
        }
    }
