    <telerikGrid:RadGridView x:Name="CmbContest" ItemsSource="{Binding CmbContest}" AutoGenerateColumns="False" >
        <telerikGrid:RadGridView.Columns>
            <telerikGrid:GridViewDataColumn Header="TestColumn" DataMemberBinding="{Binding Name}" ></telerikGrid:GridViewDataColumn>
            <local:MultiDropDownColumn Header="SelectColumn" SelectedItem="SelectedDropDown" />
        </telerikGrid:RadGridView.Columns>
    </telerikGrid:RadGridView>
