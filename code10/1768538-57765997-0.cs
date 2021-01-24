    public IActionResult Error()
    {
        var requestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
        return this.View(new ErrorViewModel { RequestId = requestId });
    }
