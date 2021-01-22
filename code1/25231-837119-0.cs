    <DataTemplate x:Key="ImageColumn">
        <ContentControl x:Name="content">
            <Image Source="MyImage.png"/>
        </ContentControl>
        <DataTemplate.Triggers>
            <DataTrigger Binding="{Binding TriggerProperty}" Value="2">
                <Setter TargetName="content" Property="Content">
                    <Setter.Value>
                        <Rectangle Fill="Red"/>
                    </Setter.Value>
                </Setter>
            </DataTrigger>
            <!--etc...-->
        </DataTemplate.Triggers>
    </DataTemplate>
