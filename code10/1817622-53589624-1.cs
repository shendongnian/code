    public class SC
    {
        public bool IsFB { get; set; } = true;
    }
    <Window.Resources>
        <vm:MainViewModel x:Key="myKey"/>
    </Window.Resources>
    ...
    <DataTrigger Binding="{Binding Source={StaticResource myKey}, Path=IsFB}" Value="True">
        <Setter Property="Background" Value="Red"/>
    </DataTrigger>
