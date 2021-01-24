    <DataTemplate>
        <Button BorderThickness="0" ToolTip="Delete a User" Click="DeleteTaskUser_OnClick" Name="DeleteUserButton">
            <Button.Style>
                <Style TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding UserId}" Value="{x:Static local:Identity.This.OnBehalfOfUser.UserId}">
                            <Setter Property="IsEnabled" Value="False" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
            <Button.Content>
                <Image Source="/Sinergi;component/Images/Trash-can-icon16.png" />
            </Button.Content>
        </Button>
    </DataTemplate>
