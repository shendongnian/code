		using System.Windows.Data;
		//...
		Person p = new Person();
		Binding ageBinding = new Binding("Age");
		ageBinding.Source = p;
		MyWpfLabelControl.SetBinding(Label.ContentProperty, ageBinding);
	Now whenever p.GetOlder() is called MyWpfLabelControl.Content will change to the new p.Age value.		
