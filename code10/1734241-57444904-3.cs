csharp
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
public class App : Xamarin.Forms.Application
{
    public App()
    {
        var navigationPage = new Xamarin.Forms.NavigationPage(new MyContentPage());
 
        navigationPage.On<iOS>().SetPrefersLargeTitles(true);
        MainPage = navigationPage;
    }
}
### ISearchPage Interface
Create an Interface that can be used across the Xamarin.Forms, Xamarin.Android and Xamarin.iOS projects.
csharp
public interface ISearchPage
{
    void OnSearchBarTextChanged(in string text);
    event EventHandler<string> SearchBarTextChanged;
}
### Xamarin.Forms Page
csharp
public class MyContentPage : ContentPage, ISearchPage,
{
    public MyContentPage()
    {
        SearchBarTextChanged += HandleSearchBarTextChanged
    }
    public event EventHandler<string> SearchBarTextChanged;
    public void OnSearchBarTextChanged(in string text) => SearchBarTextChanged?.Invoke(this, text);
    void HandleSearchBarTextChanged(object sender, string searchBarText)
    {
        //Logic to handle updated search bar text
    }     
}
### iOS Custom Renderer
csharp
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using MyNamespace;
using MyNamespace.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(MyContentPage), typeof(SearchPageRenderer))]
namespace MyNamespace.iOS
{
    public class SearchPageRenderer : PageRenderer, IUISearchResultsUpdating
    {
        bool _isFirstAppearing = true;
        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);
            var searchController = new UISearchController(searchResultsController: null)
            {
                SearchResultsUpdater = this,
                DimsBackgroundDuringPresentation = false,
                HidesNavigationBarDuringPresentation = false,
                HidesBottomBarWhenPushed = true
            };
            searchController.SearchBar.Placeholder = string.Empty;
            parent.NavigationItem.SearchController = searchController;
            DefinesPresentationContext = true;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            //Work-around to ensure the SearchController appears when the page first appears https://stackoverflow.com/a/46313164/5953643
            if (_isFirstAppearing)
            {
                ParentViewController.NavigationItem.SearchController.Active = true;
                ParentViewController.NavigationItem.SearchController.Active = false;
                _isFirstAppearing = false;
            }
        }
        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            if (Element is ISearchPage searchPage)
                searchPage.OnSearchBarTextChanged(searchController.SearchBar.Text);
        }
    }
}
### Xamarin.Android Menu XML
1. In the Xamarin.Android project, in the `Resources` folder, create a new folder called `menu`  (if one doesn't already exist).
   - **Note**: the folder, `menu`, has a lowercase 'm'
2. In the `Resources > menu` folder, create a new file called `MainMenu.xml`.
[![enter image description here][1]][1]
3. Open `Resources > menu > MainMenu.xml`
4. In `MainMenu.xml` add the following code:
xml
<?xml version="1.0" encoding="utf-8" ?>
<menu xmlns:android="http://schemas.android.com/apk/res/android"
      xmlns:app="http://schemas.android.com/apk/res-auto">
  <item android:id="@+id/ActionSearch"
        android:title="Filter"
        android:icon="@android:drawable/ic_menu_search"
        app:showAsAction="always|collapseActionView"
        app:actionViewClass="android.support.v7.widget.SearchView"/>
</menu>
### Xamarin.Android CustomRenderer
Uses the [Plugin.CurrentActivity NuGet Package](https://www.nuget.org/packages/Plugin.CurrentActivity/).
csharp
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views.InputMethods;
using Plugin.CurrentActivity;
using MyNamespace;
using MyNamespace.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(MyContentPage), typeof(SearchPageRenderer))]
namespace MyNamespace.Droid
{
    public class SearchPageRenderer : PageRenderer
    {
        public SearchPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            if (Application.Current.MainPage is NavigationPage navigationPage)
                navigationPage.Popped += HandleNavigationPagePopped;
            if (Element is ISearchPage && Element is Page page)
                AddSearchToToolbar(page);
        }
        protected override void Dispose(bool disposing)
        {
            if (GetToolbar() is Toolbar toolBar)
                toolBar.Menu?.RemoveItem(Resource.Menu.MainMenu);
            base.Dispose(disposing);
        }
        void AddSearchToToolbar(in Page page)
        {
            if (GetToolbar() is Toolbar toolBar
                && toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>().GetType() != typeof(SearchView))
            {
                toolBar.Title = page.Title;
                toolBar.InflateMenu(Resource.Menu.MainMenu);
                if (toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>() is SearchView searchView)
                {
                    searchView.QueryTextChange += HandleQueryTextChange;
                    searchView.ImeOptions = (int)ImeAction.Search;
                    searchView.InputType = (int)InputTypes.TextVariationNormal;
                    searchView.MaxWidth = int.MaxValue; //Set to full width - http://stackoverflow.com/questions/31456102/searchview-doesnt-expand-full-width
                }
            }
        }
        void HandleQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (Element is ISearchPage searchPage)
                searchPage.OnSearchBarTextChanged(e.NewText);
        }
        void HandleNavigationPagePopped(object sender, NavigationEventArgs e)
        {
            if (sender is NavigationPage navigationPage
                && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar(navigationPage.CurrentPage);
            }
        }
        Toolbar GetToolbar() => CrossCurrentActivity.Current.Activity.FindViewById<Toolbar>(Resource.Id.toolbar);
    }
}
![iOS Search Bar Sample][2]
![Android Search Bar Sample][3]
  [1]: https://i.stack.imgur.com/Dxk7O.png
  [2]: https://i.stack.imgur.com/eOjCN.png
  [3]: https://i.stack.imgur.com/tp8De.png
