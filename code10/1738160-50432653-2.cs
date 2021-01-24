    <?xml version="1.0" encoding="UTF-8"?>
    <ContentPage
        xmlns="http://xamarin.com/schemas/2014/forms"
        xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
        xmlns:local="clr-namespace:SliderTest"
        x:Class="SliderTest.MyPage"
        Padding="50">
        <ContentPage.BindingContext>
            <local:MainViewModel />
        </ContentPage.BindingContext>
        <ContentPage.Content>
            <StackLayout>
            <Slider x:Name="slider" Maximum="5" Minimum="1" Value="{Binding SliderValue}" />
            <Label Text="{Binding Source={x:Reference Name=slider}, Path=Value}" HorizontalOptions="Center" VerticalOptions="CenterAndExpand" />
        </StackLayout>
        </ContentPage.Content>
    </ContentPage>
    
    public class MainViewModel : INotifyPropertyChanged
    {
    	int sliderValue;
    	public int SliderValue
    	{
    		get => sliderValue;
    		set
    		{
    			sliderValue = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	void OnPropertyChanged([CallerMemberName] string propertyName = "")
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
