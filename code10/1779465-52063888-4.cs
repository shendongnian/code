    ...
    <DataGridTemplateColumn Header="City">
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>                           
                <Grid>
                    <TextBox Text="{Binding SelectedCity, Mode=TwoWay}">
                        <TextBox.Style>
                            <Style TargetType="TextBox">
                                <Setter Property="Visibility" Value="Collapsed"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding Cities}" Value="{x:Null}">
                                        <Setter Property="Visibility" Value="Visible"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </TextBox.Style>
                    </TextBox>
                    <ComboBox ItemsSource="{Binding Cities}" 
                          SelectedItem="{Binding SelectedCity, Mode=TwoWay}">
                        <ComboBox.Style>
                            <Style TargetType="ComboBox">
                                <Setter Property="Visibility" Value="Visible"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding Cities}" Value="{x:Null}">
                                        <Setter Property="Visibility" Value="Collapsed"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </ComboBox.Style>
                    </ComboBox>
                </Grid>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
    ...
