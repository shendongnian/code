    protected override void OpenMediaAsync()
    {
    ...
    mediaSourceAttributes[MediaSourceAttributesKeys.Duration] = TimeSpan.FromHours(10).Ticks.ToString(CultureInfo.InvariantCulture);
    this.ReportOpenMediaCompleted(mediaSourceAttributes, mediaStreamDescriptions);
    }
     
