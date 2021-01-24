cs
var recipients = users
    .OfType<IGuildUser>()
    .Where
    (
        u => !u.IsBot && !u.IsWebhook
    );
var tasks = recipients
    .Select
    (
        r => r.SendMessageAsync("Hi")
    );
try
{
    await Task.WhenAll( tasks );
}
catch
{
    var exceptions = tasks.Where(t => t.Exception != null)
                          .Select(t => t.Exception);
}
