    <DataGridTemplateColumn.CellTemplate>
           <DataTemplate>
                 <Label Content="{Binding Name}" Width="350">
                       <i:Interaction.Triggers>
                             <i:EventTrigger EventName="MouseDown">
                                      <i:InvokeCommandAction Command="{Binding DataContext.ExpandAppDetailsCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                              </i:EventTrigger>
                        </i:Interaction.Triggers>
                     </Label>
               </DataTemplate>                
    </DataGridTemplateColumn.CellTemplate>
