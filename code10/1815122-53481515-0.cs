    <DataGrid>
       <DataGrid.Columns>
          <DataGridTemplateColumn Header="Catalog Number"  Width="1*">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Grid>
                            <TextBlock Text="{Binding JobInfo.Jobname}">
                                <TextBlock.Style>
                                    <Style TargetType="TextBlock">
                                        <Style.Triggers>
                                            <Setter Property="Visibility" Value="Visible"/>
                                            <DataTrigger Binding="{Binding IsComboBox}" Value="True">
                                                <Setter Property="Visibility" Value="Hidden"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </TextBlock.Style>
                            </TextBlock>
                            <ComboBox>
                                <ComboBox.Style>
                                    <Style TargetType="ComboBox">
                                        <Style.Triggers>
                                            <Setter Property="Visibility" Value="Hidden"/>
                                            <DataTrigger Binding="{Binding IsComboBox}" Value="True">
                                                <Setter Property="Visibility" Value="Visible"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </ComboBox.Style>
                            </ComboBox>
                        </Grid>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
             </DataGridTemplateColumn>
          <DataGridTextColumn Header="Description"  Width="1*" />
       </DataGrid.Columns>
    </DataGrid>
