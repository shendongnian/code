    <dg:DataGridTextColumn Binding="{Binding Operation}" CanUserReorder="True" CanUserResize="True" Header="Operation" />
                <dg:DataGridTemplateColumn CanUserReorder="True" CanUserResize="True" Header="Template Column">
                    <dg:DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding Data}" SelectedItem="{Binding Operation}" />
                        </DataTemplate>
                    </dg:DataGridTemplateColumn.CellTemplate>
                </dg:DataGridTemplateColumn>
                <dg:DataGridComboBoxColumn
                    Header="ComboBox Column"                                             
                    Width="100"                                       
                     SelectedValueBinding="{Binding Operation}"                     
                     SelectedItemBinding="{Binding Operation}">
                    <dg:DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="IsSynchronizedWithCurrentItem" Value="False" />
                            <Setter Property="ItemsSource" Value="{Binding Data}" />
                        </Style>
                    </dg:DataGridComboBoxColumn.ElementStyle>
                    <dg:DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Data}" />
                            <Setter Property="IsDropDownOpen" Value="True" />
                        </Style>
                    </dg:DataGridComboBoxColumn.EditingElementStyle>
                </dg:DataGridComboBoxColumn>
