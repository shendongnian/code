	var binding = new Binding
	{
		Path = new PropertyPath("BackgroundProperty"),
		Mode = BindingMode.OneWay,
		UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
		};
	var run = new Run();
	BindingOperations.SetBinding(run, Run.TextProperty, binding);
	para.Inlines.Add(new Bold(run));
