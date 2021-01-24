    using System;
    
    using Xamarin.Forms;
    
    namespace DynamicStackLayoutSize
    {
    	public class App : Application
    	{
    		public App() => MainPage = new MyPage();
    	}
    
    	class MyPage : ContentPage
    	{
    		readonly StackLayout _adjustableStackLayout;
    
    		public MyPage()
    		{
    			_adjustableStackLayout = new StackLayout
    			{
    				HorizontalOptions = LayoutOptions.Center,
    				VerticalOptions = LayoutOptions.Center,
    				BackgroundColor = Color.Green,
    				Children = {
    					new Label{ Text = "Hello" },
    					new Label{ Text = "World" }
    				}
    			};
    
    			var resizeButton = new Button { Text = "Resize" };
    			resizeButton.Clicked += (s, e) =>
    			{
    				if (_adjustableStackLayout.HeightRequest == 196)
    					ResizeStackLayout(-1);
    				else
    					ResizeStackLayout(196);
    			};
    
    			Content = new StackLayout
    			{
    				HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
    				BackgroundColor = Color.Red,
    				Children ={
    					_adjustableStackLayout,
    					resizeButton
    				}
    			};
    		}
    
    		void ResizeStackLayout(double heightRequest)
    		{
    			Device.BeginInvokeOnMainThread(() =>
    			{
    				_adjustableStackLayout.HeightRequest = heightRequest;
    				_adjustableStackLayout.ForceLayout();
    				this.ForceLayout();
    			});
    		}
    	}
    }
