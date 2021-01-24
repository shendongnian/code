    <Window.Resources>
            <ResourceDictionary>
                <DataTemplate x:Key="DTGlobalAdminManager">
                    <AC:UCGlobalAdmin DataContext="{Binding Source={x:Static GVM:VMAdminConsole.Instance}, Path=ViewModelGlobalAdmin}"/>
                </DataTemplate>
                <DataTemplate x:Key="DTCompanyAdminProjects">
                    <AC:UCCompanyAdmin DataContext="{Binding Source={x:Static GVM:VMAdminConsole.Instance}, Path=ViewModelCompanyAdmin}" />
                </DataTemplate>
                <DataTemplate x:Key="DTProjectAdminManager">
                    <AC:UCProjectAdminManage DataContext="{Binding Source={x:Static GVM:VMAdminConsole.Instance}, Path=ViewModelProjectAdmin}"/>
                </DataTemplate>
                <DataTemplate x:Key="DTGlobalAdminAssignCategories">
                    <AC:UCGlobalAdminCategories DataContext="{Binding Source={x:Static GVM:VMAdminConsole.Instance}, Path=ViewModelGlobalAdmin}"/>
                </DataTemplate>
            </ResourceDictionary>
        </Window.Resources>
