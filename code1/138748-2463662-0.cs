//View Model
[OptionsFrom("Years")]
public int ContractYear{ get; set; }
public IDictionary<int, string> Years
{
	get
	{
		var currentYear = DateTime.Today.Year;
		return Enumerable.Range(0, 10).ToDictionary(i => currentYear + i, i => (currentYear + i).ToString());
	}
}
//View
Html.InputFor(x => x.ContractYear);
