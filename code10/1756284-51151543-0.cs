    [JsonObject]
    public class PerformanceMetricsItemDtoX
    {
        public CallType CallType { get; set; } //=> CallType is an enum
        public DateTime ExecutionStart { get; set; }
        public DateTime ExecutionEnd { get; set; }
        public DateTime UnitExecutionStart { get; set; }
        public long OverallExecution { get; set; }
    }
