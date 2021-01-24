    public class TemplSelector : DataTemplateSelector
    {
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var element = container as FrameworkElement;
    
        if (element != null && item != null)
        {
            var vm = (ViewModel)item;
    
            if (vm.YourEnum == 1)
                return element.FindResource("templ1") as DataTemplate;
            else if (vm.YourEnum == 0)
                return element.FindResource("templ0") as DataTemplate;
        }
    
        return null;
    }
    }
    <Window.Resources>
        <local:TemplSelector x:Key="templSel"/>        
    </Window.Resources>
    <ContentPresenter ContentTemplateSelector="{StaticResource templSel}" Content="{Binding ViewModel}">
        <ContentPresenter.Resources>
            <DataTemplate x:Key="templ0">
                <TextBlock>
                    Please wait
                </TextBlock>
            </DataTemplate>
            <DataTemplate x:Key="templ1">
                <TextBlock>
                    Searching for item. <Hyperlink Command="{Binding DetailsCommand}">Link to details</Hyperlink>
                </TextBlock>
            </DataTemplate>
        </ContentPresenter.Resources>
    </ContentPresenter>
