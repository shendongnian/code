            <dg:DataGridComboBoxColumn 
               Header="String Column" 
               SelectedItemBinding="{Binding Path=RoleProperty}">
               <dg:DataGridComboBoxColumn.ItemsSource>
                  <CompositeCollection>
                     <system:String>Employee</system:String>
                     <system:String>Contractor</system:String>
                     <system:String>Supplier</system:String>
                  </CompositeCollection>
               </dg:DataGridComboBoxColumn.ItemsSource>
            </dg:DataGridComboBoxColumn>
