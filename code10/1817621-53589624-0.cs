    public static class SC
    {
        public static bool IsFB { get; set; } = true;
    }
    <DataTrigger Binding="{Binding Source={x:Static vm:SC.IsFB}}" Value="True">
        <Setter Property="Background" Value="Red"/>
    </DataTrigger>
