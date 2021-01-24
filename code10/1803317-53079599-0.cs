    <DataGridColumnHeadersPresenter Grid.Column="1" x:Name="PART_ColumnHeadersPresenter"
       Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Column}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}">
       <DataGridColumnHeadersPresenter.Template>
           <ControlTemplate TargetType="{x:Type DataGridColumnHeadersPresenter}">
               <Grid HorizontalAlignment="Left">
                   <ItemsPresenter />
                   <DataGridColumnHeader x:Name="PART_FillerColumnHeader" IsHitTestVisible="False">
                       <DataGridColumnHeader.Template>
                           <ControlTemplate TargetType="{x:Type DataGridColumnHeader}">
                               <Grid>
                                   <Border BorderThickness="2" BorderBrush="Red">
                                       <ContentPresenter RecognizesAccessKey="True" 
                                                         SnapsToDevicePixels="True" />
                                   </Border>
                                   <!--Uncomment if you need these resizing grippers-->
                                   <!--<Thumb x:Name="PART_LeftHeaderGripper" HorizontalAlignment="Left" />
                                   <Thumb x:Name="PART_RightHeaderGripper" HorizontalAlignment="Right" />-->
                               </Grid>
                           </ControlTemplate>
                       </DataGridColumnHeader.Template>
                   </DataGridColumnHeader>
               </Grid>
           </ControlTemplate>
       </DataGridColumnHeadersPresenter.Template>
    </DataGridColumnHeadersPresenter>
