    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding Path=MenuModel.IsVisible, RelativeSource={RelativeSource Self}}" Value="True" />
            <Condition Binding="{Binding Path=Tier, Source={x:Static local:RenderCapabilityWrapper.Instance}}" Value="0" />
        </MultiDataTrigger.Conditions>
        <MultiDataTrigger.EnterActions>
            <BeginStoryboard Storyboard="{StaticResource FadeInMenu}" />
            <BeginStoryboard Storyboard="{StaticResource FadeOutContentLow}" />
        </MultiDataTrigger.EnterActions>
        <MultiDataTrigger.ExitActions>
            <BeginStoryboard Storyboard="{StaticResource FadeOutMenu}" />
            <BeginStoryboard  Storyboard="{StaticResource FadeInContentLow}" />
        </MultiDataTrigger.ExitActions>
    </MultiDataTrigger>
