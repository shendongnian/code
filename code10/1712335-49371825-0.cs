    var result = await graphClient.Me.FindMeetingTimes()
        .Request()
        .PostAsync();
    
    if (!string.IsNullOrWhiteSpace(result.EmptySuggestionsReason))
    {
        Console.WriteLine(result.EmptySuggestionsReason);
    }
    else
    {
        foreach (var item in result.MeetingTimeSuggestions)
        {
            Console.WriteLine($"Suggestion: {item.SuggestionReason}");
        }
    }
