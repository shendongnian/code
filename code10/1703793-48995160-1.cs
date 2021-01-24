     <StackPanel>
        <ComboBox Name="CSCB" IsEditable="True" IsReadOnly="True" Margin="8" 
                  ItemsSource="{Binding Systems, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
                  DisplayMemberPath="Name"
                  SelectedItem="{Binding SelectedCoord, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"
                  Text="Select a Coordinate System"
        />
        <TextBox Text="{Binding SelectedCoord.Name,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" TextChanged="TextBoxBase_OnTextChanged"></TextBox>
    </StackPanel>
