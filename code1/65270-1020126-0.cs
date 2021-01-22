    <ContentPresenter Content="{Binding}">
        <ContentPresenter.ContentTemplate>
            <DataTemplate>
                <Grid>
                    <ListView Name="list" ItemsSource="{Binding MyList}"/>
                    <TextBlock Name="empty" Text="No items found" Visibility="Collapsed"/>
                </Grid>
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding MyList.Count}" Value="0">
                        <Setter TargetName="list" Property="Visibility" Value="Collapsed"/>
                        <Setter TargetName="empty" Property="Visibility" Value="Visible"/>
                    </DataTrigger>                        
                </DataTemplate.Triggers>
            </DataTemplate>
        </ContentPresenter.ContentTemplate>
    </ContentPresenter>
