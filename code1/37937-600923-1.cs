    public class Country
    {
        public string Name { get; set; }
        public IList<City> Cities { get; set; }
        public Country()
        {
            Cities = new List<City>();
        }
    }
    public class City 
    {
        public string Name { get; set; } 
    }
    List<Country> Countries = new List<Country>
    {
        new Country
        {
            Name = "Germany",
            Cities =
            {
                new City {Name = "Berlin"},
                new City {Name = "Hamburg"}
            }
        },
        new Country
        {
            Name = "England",
            Cities =
            {
                new City {Name = "London"},
                new City {Name = "Birmingham"}
            }
        }
    };
    bindingSource1.DataSource = Countries;
    member_CountryComboBox.DataSource = bindingSource1.DataSource;
    member_CountryComboBox.DisplayMember = "Name";
    member_CountryCombo
    Box.ValueMember = "Name";
