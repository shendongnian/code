    public class StringSetIgnoreCase : HashSet<string>
    {
        public StringSetIgnoreCase()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
---
    // GET /api/people?names=john&names=JOHN&names=alice
    [HttpGet("api/people")]
    public GetPeople([FromQuery] StringSetIgnoreCase names)
    {
        // names contains only john and alice
    }
