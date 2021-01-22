    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="linkTemplate">
                <TextBlock>
                    <Hyperlink>
                        <TextBlock 
                            Text="{Binding 
                                Value.Name, 
                                    RelativeSource={RelativeSource FindAncestor, 
                                    AncestorType={x:Type telerik:GridViewCell}}}" />
                    </Hyperlink>
                </TextBlock>
            </DataTemplate>
        </Grid.Resources>
        <telerik:RadGridView ItemsSource="{Binding}" AutoGenerateColumns="False">
            <telerik:RadGridView.Columns>
                <telerik:GridViewDataColumn 
                    DataMemberBinding="{Binding Distributor1}" 
                    CellTemplate="{StaticResource linkTemplate}" />
                <telerik:GridViewDataColumn 
                    DataMemberBinding="{Binding Distributor2}" 
                    CellTemplate="{StaticResource linkTemplate}" />
            </telerik:RadGridView.Columns>
        </telerik:RadGridView>
    </Grid>
