enum Country
{
	UnitedKingdom,
	UnitedStates,
	France,
	Portugal
}
enum CountryCode
{
	UK,
	US,
	FR,
	PT
}
void Main()
{
	string countryCode = ((CountryCode)Country.UnitedKingdom).ToString();
	Console.WriteLine(countryCode);
	countryCode = ((CountryCode)Country.Portugal).ToString();
	Console.WriteLine(countryCode);
}
</pre>
