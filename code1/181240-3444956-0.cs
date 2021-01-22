    <ListView Name="lvEverything">
        <ListView.Resources>
            <Style TargetType="{x:Type GridViewColumnHeader}">
                <Setter Property="LayoutTransform">
                    <Setter.Value>
                        <RotateTransform Angle="-90"/>
                    </Setter.Value>
                </Setter>
                <Setter Property="Width" Value="250"></Setter>
            </Style>
            <Style x:Key="FirstColumnStyle" TargetType="GridViewColumnHeader"/>
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="First Column"
                    DisplayMemberBinding="{Binding FirstColumn}"
                    HeaderContainerStyle="{StaticResource FirstColumnStyle}"/>
                <GridViewColumn Header="Second Column"
                    DisplayMemberBinding="{Binding SecondColumn}"/>
            </GridView>
        </ListView.View>
    </ListView>
