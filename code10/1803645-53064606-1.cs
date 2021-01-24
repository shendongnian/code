     <telerik:RadGridView  Grid.Row="7" Grid.Column="1" Grid.ColumnSpan="2" ShowGroupPanel="False" 
                                                  Name="InventoryDetailsGrid"
                                                  Foreground="#357BCC"                                              
                                                  GridLinesVisibility="Horizontal"
                                                  AutoGenerateColumns="False">
                                <telerik:RadGridView.Columns>
                                    <telerik:GridViewHyperlinkColumn Header="Path" DataMemberBinding="{Binding Path}" />
                                    <telerik:GridViewDataColumn DataMemberBinding="{Binding Title}" Header="Title" IsReadOnly="True"/>
                                    <telerik:GridViewDataColumn DataMemberBinding="{Binding Size}" Header="Size" IsReadOnly="True"/>
                                    <telerik:GridViewDataColumn DataMemberBinding="{Binding PathLength}" Header="Path Length" IsReadOnly="True"/>
                                    <telerik:GridViewDataColumn DataMemberBinding="{Binding FileExtension}" Header="FileExtension" IsReadOnly="True"/>
                                    <telerik:GridViewDataColumn DataMemberBinding="{Binding OfItem}" Header="Of Item" IsReadOnly="True"/>
                                </telerik:RadGridView.Columns>                          
    
    </telerik:RadGridView> 
  
