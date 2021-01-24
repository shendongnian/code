    <td>
        @Model.ProcessedOn.Value.ToUniversalTime() UTC
        @if (Model.ProcessedOn.Value != null)
        {
            DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond)) - DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond)
        }
    }
    </td>
