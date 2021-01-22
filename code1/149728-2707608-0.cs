            <ListView.Resources>
                <DataContextSpy x:Name="spy" />
                <ContextMenu x:Key="ItemContextMenu">
                    <MenuItem Header="Add" />
                    <MenuItem Header="Edit"/>
                    <Separator/>
                    <MenuItem Header="Delete" Command="{Binding DataContext.Msg,Source={StaticResource spy}}" /> 
                </ContextMenu>
            </ListView.Resources>
