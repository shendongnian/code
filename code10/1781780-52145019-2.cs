    <Window.Resources>
        <local:DateConverter x:Key="dateConverter" />
    </Window.Resources>
    
    <Grid>
        <Calendar x:Name="MyCal" 
                  SelectionMode="MultipleRange" 
                  SelectedDatesChanged="OnSelectedDatesChanged">
            <Calendar.CalendarDayButtonStyle>
                <Style TargetType="CalendarDayButton">
                    <Setter Property="Background" >
                        <Setter.Value>
                            <MultiBinding Converter="{StaticResource dateConverter}">
                                <Binding />
                                <Binding RelativeSource="{RelativeSource AncestorType=Window, Mode=FindAncestor}" Path="DataContext.HolidayDateCollection"  UpdateSourceTrigger="PropertyChanged"/>
                                <Binding RelativeSource="{RelativeSource AncestorType=Window, Mode=FindAncestor}" Path="DataContext.ShutDownDateCollection" UpdateSourceTrigger="PropertyChanged"/>
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Calendar.CalendarDayButtonStyle>
        </Calendar>
     </Grid>
