    <ContentView xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:effects="clr-namespace:VMSTablet.Effects;assembly=VMSTablet"
             x:Class="VMSTablet.Controls.StandardFormEntry"
             x:Name="CustomEntryControl">
    <StackLayout >
        <Label  Text="{Binding LabelText}" Style="{StaticResource DefaultLabelStyle}" TextColor="{StaticResource DarkGreenColor}"/>
        <Entry x:Name="CustomEntry" Text="{Binding Text}" 
               IsEnabled="{Binding IsEntryEnabled, Source={x:Reference CustomEntryControl}}" 
               Keyboard="{Binding Keyboard}" 
               Behaviors="{Binding Behaviors}" 
               TextColor="{StaticResource DarkGreenColor}"
               Placeholder="{Binding Placeholder}" Style="{StaticResource DefaultEntryStyle}" >
            <Entry.Effects>
                <effects:EntryBarColorEffect/>
            </Entry.Effects>
        </Entry>
    </StackLayout>
