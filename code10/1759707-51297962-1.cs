	HumanAnalysisService has = null;
	try
	{
		has = new HumanAnalysisService("license.xml", "", 20, 4);
	} 
	catch (ApplicationException lie)
	{
		Console.WriteLine(lie.Message);
		return;
	}
	// has = new HumanAnalysisService("license.xml", "", 20, 4);
	/* attach to camera device */
	// has.initUsingCameraSource(0);
	has.initUsingImageSource(file1);
	IJobDetail job = JobBuilder.Create<CaptureFeedFeedbackLoopJob>().WithIdentity("job1", "group1").Build();
	ITrigger trigger = TriggerBuilder.Create()
	.WithIdentity("trigger1", "group1")
	.StartNow()
	.WithSimpleSchedule(x => x
		.WithIntervalInSeconds(60)
		.RepeatForever())
	.Build();
	
	await scheduler.ScheduleJob(job, trigger);
	
