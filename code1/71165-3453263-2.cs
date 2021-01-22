            <StackPanel Orientation="Horizontal">
               <Button Click="RaiseEvent_Click">Raise UpdateTable Event</Button>
            </StackPanel>
            <RichTextBox>
               <FlowDocument>
                  <Table Name="MyTable"
                        l:TableHandler.HandleTable="True"
                        l:TableHandler.UpdateTable="MyTable_UpdateTable">
                     <Table.Columns>
                        <TableColumn/>
                        <TableColumn/>
                     </Table.Columns>
                  </Table>
               </FlowDocument>
            </RichTextBox>
