    <ListView.ItemTemplate>
        <DataTemplate>
            <ToggleButton Content="{Binding}" 
                          Width="{Binding ActualWidth, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}}}"
                          IsChecked="{Binding IsSelected, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}}}">
                <ToggleButton.Template>
                    <ControlTemplate TargetType="ToggleButton">
                        <Border BorderThickness="0">
                            <ContentPresenter/>
                        </Border>
                    </ControlTemplate>
                </ToggleButton.Template>
            </ToggleButton>
        </DataTemplate>
    </ListView.ItemTemplate>
