csharp
var activity = turnContext.Activity;
if (string.IsNullOrWhiteSpace(activity.Text))
{
	activity.Text = JsonConvert.SerializeObject(activity.Value);
}
