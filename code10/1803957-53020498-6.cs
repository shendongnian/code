    <StackPanel DataContext="{Binding Path=(p:Settings.Default)}">
        <CheckBox Content="Quick process" IsChecked="{Binding Pref_QuickProcess}"/>
        <CheckBox Content="Upload to Youtube">
            <CheckBox.Style>
                <Style TargetType="CheckBox">
                    <Setter Property="IsChecked" Value="{Binding Pref_UploadToYoutube}"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Pref_QuickProcess}" Value="True">
                            <Setter Property="IsChecked" Value="False"/>
                            <Setter Property="IsEnabled" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </CheckBox.Style>
        </CheckBox>
    </StackPanel>
