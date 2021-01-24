    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Label Grid.Row="1" Grid.Column="1"  Content="{Binding Path=DataContext.ID, RelativeSource={RelativeSource AncestorType=ItemsControl}, UpdateSourceTrigger=PropertyChanged}">
                    <Label.Visibility>
                        <MultiBinding>
                            <MultiBinding.Converter>
                                <local:MultiConverter />
                            </MultiBinding.Converter>
                            <Binding Path="." RelativeSource="{RelativeSource AncestorType=ItemsControl}" />
                            <Binding Path="." />
                        </MultiBinding>
                    </Label.Visibility>
                </Label>
            </Grid>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
