    <ComboBox Width="300" Height="30" ItemsSource="{Binding Path=Model.Names, Mode=OneWay}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid x:Name="templateGrid">
                    <TextBox Text="{Binding Name}" />
                </Grid>
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding isMismatch}" Value="True">
                       <Setter TargetName="templateGrid" 
                               Property="Background" Value="Red" />         
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
