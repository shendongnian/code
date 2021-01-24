    using System.Collections.Generic;
    using Xamarin.Forms;
    
    namespace MyNamespace
    {
        public class MyClass : CarouselPage
        {
    
            protected override void OnAppearing()
            {
                base.OnAppearing();
    
               foreach (var child in Children)
               {
                    if (child != CurrentPage)
                    Children.Remove(child);
               }
             }
    
             public void DisplayPage(ContentPage page)
             {
                Children.Clear();
                Children.Add(page);
             }
         }
    }
