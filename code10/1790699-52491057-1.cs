    public class MyPageRenderer : PageRenderer
        {
            MyPage myPage;
            //...
            protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
            {
                myPage = (MyPage)e.NewElement;
                //...
            }
            private void ButtonTapped(object sender, EventArgs e)
            {
    
                //do something
                myPage.RaiseSomeButtonClicked();
    
            }
        }
