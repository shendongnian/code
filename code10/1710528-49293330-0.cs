    <ComboBox ItemsSource="{Binding MyList}" ... >
        <ComboBox.Template>
            <ControlTemplate TargetType="ComboBox">
                <Grid>
                    <ComboBox x:Name="cbItems" 
                        DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" 
                        ItemsSource="{Binding ItemsSource, RelativeSource={RelativeSource TemplatedParent}}"
                        SelectedValue ="{Binding SelectedValue, RelativeSource={RelativeSource TemplatedParent}}" 
                        />
                    <TextBlock x:Name="tbItem" Text="Add New" IsHitTestVisible="False" Visibility="Hidden"/>
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger SourceName="cbItems" Property="SelectedItem" Value="{x:Null}">
                        <Setter TargetName="tbItem" Property="Visibility" Value="Visible"/>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </ComboBox.Template>
    </ComboBox>
