    public FooMap()
		{
			Id(x => x.Id);
			Component<Bar>(x => x.Bar, m =>
			{
				m.Map(x => x.Text);
			});
		}
