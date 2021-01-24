            <ComboBox Width="200" Height="30"  ItemsSource="{Binding SimpleList, UpdateSourceTrigger=PropertyChanged}" >
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <Label Content="{Binding Name}" Background="{Binding BackGround}" Foreground="{Binding ForeGround}"/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
