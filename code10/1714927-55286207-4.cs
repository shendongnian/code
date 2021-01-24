    public class MyPage : CarouselPage
    {
        ContentPage ChildPage1 = new ContentPage();
        ContentPage ChildPage2 = new ContentPage();
    
        public MyPage()
        {
            Padding = new Thickness(0, 30, 0, 0);
            Children.Add(ChildPage1);
            Children.Add(ChildPage2);
            CurrentPage = ChildPage1;
        }
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
    
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i] != CurrentPage)
                    Children.Remove(Children[i]);
            }
        }
    
        public void DisplayPage(ContentPage page)
        {
            Children.Clear();
            Children.Add(page);
        }
    }
