    // remove some unnecessary namespaces
    using System.Net;
    using System.Net.Http.Headers;
    using System.Text;
    using Ical.Net;
    using Ical.Net.DataTypes;
    using Ical.Net.CalendarComponents;
    using Ical.Net.Serialization;
    // remove async as the method has no await method
    public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
    {
        ... // remain the same
        // Event is deprecated in new version, use CalendarEvent
        var icalevent = new CalendarEvent{...}
        ... // remain the same
    }
