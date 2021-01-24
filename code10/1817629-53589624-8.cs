    public static class Globals
    {
        public static bool IsFB = true;
    }
    <DataTrigger Binding="{Binding Source={x:Static vm:Globals.IsFB}}" Value="True">
        <Setter Property="Background" Value="Red"/>
    </DataTrigger>
