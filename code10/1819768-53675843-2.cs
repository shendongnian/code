    <ContentControl Grid.Column="0" Grid.Row="7" Grid.ColumnSpan="3" >
        <ContentControl.ContentTemplate>
        <DataTemplate  DataType="{x:Type ViewModels:anotherViewViewModel}">
              <Views:anotherView Content="{Binding}"/>
        </DataTemplate>
        </ContentControl.ContentTemplate>
    </ContentControl>
