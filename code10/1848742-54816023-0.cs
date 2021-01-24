    public class Payload
    {
        public string[] Pipes { get; set; }
    }
    [HttpPost("aggregate")]
    public async Task<IActionResult> GetByAggregate([FromBody]Payload payload)
    {
        if (!string.IsNullOrEmpty(pipes))
        {
            var p = PipelineDefinition<T, T>.Create(payload.Pipes.Select(BsonDocument.Parse));
            IAsyncCursor<T> result = await _monsterService.AggregateAsync(p);
            return Ok(result.ToListAsync());
        }
        return NotFound();
    }
