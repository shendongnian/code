    <DataGrid.Columns>
        <DataGridTemplateColumn>
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Path=Municipio}">
                         <TextBlock.Style>
                             <Style TargetType="TextBlock">
                                 <Setter Property="Text" Value="{Binding Path=Municipio}"></Setter>
                                 <Style.Triggers>
                                     <DataTrigger Binding="{Binding Path=Municipio}" Value="{x:Null}">
                                         <Setter Property="Text" Value="{Binding Path=CCodigoPostal.Municipio}"></Setter>
                                      </DataTrigger>
                                  </Style.Triggers>
                              </Style>
                          </TextBlock.Style>
                      </TextBlock>
                  </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>
          </DataGridTemplateColumn>
      </DataGrid.Columns>
