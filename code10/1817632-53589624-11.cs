    public class Globals
    {
        public bool IsFB { get; set; } = true;
    }
    <Window.Resources>
        <vm:Globals x:Key="myKey"/>
    </Window.Resources>
    ...
    <DataTrigger Binding="{Binding Source={StaticResource myKey}, Path=IsFB}" Value="True">
        <Setter Property="Background" Value="Red"/>
    </DataTrigger>
