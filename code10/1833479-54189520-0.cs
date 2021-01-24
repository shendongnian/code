    public class CustomDateTimePrompt : ComponentDialog
    {
    	public CustomDateTimePrompt(string dialogId)
    		: base(dialogId)
    	{
    		WaterfallStep[] waterfallSteps = new WaterfallStep[]
    		{
    			InitializeAsync,
    			ResultRecievedAsync
    		};
    
    		AddDialog(new WaterfallDialog("customDateTimePromptWaterfall", waterfallSteps));
    		AddDialog(new DateTimePrompt("datetime", ValidateDateTime));
    	}
    
    	private Task<DialogTurnResult> InitializeAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    	{
    		if (stepContext.Options is PromptOptions options)
    		{
    			if (options.Prompt == null)
    			{
    				throw new ArgumentNullException(nameof(options.Prompt));
    			}
    
    			return stepContext.PromptAsync("datetime", options, cancellationToken);
    		}
    		else
    		{
    			throw new ArgumentException("Options must be prompt options");
    		}
    	}
    
    	private Task<DialogTurnResult> ResultRecievedAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    	{
    		if (stepContext.Result is IList<DateTimeResolution> datetimes)
    		{
    			DateTime time = TimexHelper.GetDateTime(datetimes.First().Timex);
    
    			return stepContext.EndDialogAsync(time, cancellationToken);
    		}
    		else
    		{
    			throw new InvalidOperationException("Result is not datetimes");
    		}
    	}
    
    	private Task<bool> ValidateDateTime(PromptValidatorContext<IList<DateTimeResolution>> promptContext, CancellationToken cancellationToken)
    	{
    		IList<DateTimeResolution> results = promptContext.Recognized.Value;
    
    		if (results != null)
    		{
    			results = results.Where(r => !string.IsNullOrEmpty(r.Timex) && TimexHelper.IsDateTime(r.Timex)).ToList();
    
    			return Task.FromResult(results.Count > 0);
    		}
    		else
    		{
    			return Task.FromResult(false);
    		}
    	}
    }
    
    public static class TimexHelper
    {
    	public static bool IsDateTime(string timex)
    	{
    		TimexProperty timexProperty = new TimexProperty(timex);
    		return timexProperty.Types.Contains(Constants.TimexTypes.Date) || timexProperty.Types.Contains(Constants.TimexTypes.Time);
    	}
    
    	public static bool IsTimeRange(string timex)
    	{
    		TimexProperty timexProperty = new TimexProperty(timex);
    		return timexProperty.Types.Contains(Constants.TimexTypes.TimeRange) || timexProperty.Types.Contains(Constants.TimexTypes.DateTimeRange);
    	}
    
    	public static DateTime GetDateTime(string timex)
    	{
    		TimexProperty timexProperty = new TimexProperty(timex);
    		DateTime today = DateTime.Today;
    
    		int year = timexProperty.Year ?? today.Year;
    		int month = timexProperty.Month ?? today.Month;
    		int day = timexProperty.DayOfMonth ?? today.Day;
    		int hour = timexProperty.Hour ?? 0;
    		int minute = timexProperty.Minute ?? 0;
    
    		DateTime result;
    		if (timexProperty.DayOfWeek.HasValue)
    		{
    			result = TimexDateHelpers.DateOfNextDay((DayOfWeek)timexProperty.DayOfWeek.Value, today);
    			result = result.AddHours(hour);
    			result = result.AddMinutes(minute);
    		}
    		else
    		{
    			result = new DateTime(year, month, day, hour, minute, 0);
    			if (result < today)
    			{
    				result = result.AddYears(1);
    			}
    		}
    
    		return result;
    	}
    }
