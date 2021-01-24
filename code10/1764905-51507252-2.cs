    <td>
        @Model.ProcessedOn.Value.ToUniversalTime() UTC
        @if (Model.ProcessedOn.Value != null)
        {
            Model.SendingOn.Value.AddTicks(-(Model.SendingOn.Value.Ticks % TimeSpan.TicksPerSecond)) - Model.AddedOn.Value.AddTicks(-(Model.AddedOn.Value.Ticks % TimeSpan.TicksPerSecond))
        }
    </td>
