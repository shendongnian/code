    public IHttpActionResult MyAction(SearchDto dto, CancellationToken ct1)
    {
        HostingEnvironment.QueueBackgroundWorkItem(async ct2 =>
        {
            using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct1, ct2))
            {
                var result = await myService.DoWorkAsync(dto, linkedCts.Token);
            }
        });
    
        return Ok();
    }
