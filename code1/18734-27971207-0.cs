        <DataGrid AutoGenerateColumns="False" HorizontalAlignment="Stretch" Margin="12,29,12,12" Name="grid" VerticalAlignment="Stretch" Background="#FF3A81A0" AlternatingRowBackground="#FFD9EEF2" FontSize="15" RowHeaderWidth="0" KeyDown="grid_KeyDown">
            <DataGrid.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="_Encrypt Row Values" Click="MenuItem_ContextMenu_Click_EncryptRowValues" Name="MenuItem_EncryptRowValues" />
                    <MenuItem Header="De_crypt Row Values" Click="MenuItem_ContextMenu_Click_DecryptRowValues" Name="MenuItem_DecryptRowValues" />
                    <MenuItem Header="Copy Row_s" Click="MenuItem_ContextMenu_Click_CopyRows" />
                </ContextMenu>
            </DataGrid.ContextMenu>
            <DataGrid.Resources>
                //Add Encryption Menu Items
                for (int i=0; i< encryptionKeys.Count; i++)
                {
                    MenuItem keyOption = new MenuItem();
                    keyOption.Header = "_" + i.ToString() + " " + encryptionKeys[i];
                    MenuItem_EncryptRowValues.Items.Add(keyOption);
                }
                //Add Decryption Menu Items
                for (int i = 0; i < encryptionKeys.Count; i++)
                {
                    MenuItem keyOption = new MenuItem();
                    keyOption.Header = "_" + i.ToString() + " " + encryptionKeys[i];
                    MenuItem_DecryptRowValues.Items.Add(keyOption);
                }
