    //Example with first column
    <GridViewColumn Header="ID" Width="120" DisplayMemberBinding="{Binding ID}">
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                   <i:EditBox>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
