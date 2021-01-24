       public static void Main()
        {
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Country: ");
            string country = Console.ReadLine();
            Address address = new Address(street, city, country);
            Console.WriteLine();
            address.DisplayAddress();
        }
        public class Address
        {
            private string street;
            private string city;
            private string country;
            public Address(string street, string city, string country)
            {
                this.street = street;
                this.city = city;
                this.country = country;
            }
            public string Street {
                get => street;
                set => street = value;
            }
            public string City {
                get => city;
                set => city = value;
            }
            public string Country {
                get => country;
                set => country = value;
            }
            public string SetFullAddress()
            {
                return ($"Full address: {street} {city} {country}");
            }
            public void DisplayAddress()
            {
                Console.WriteLine($"Street: {Street}");
                Console.WriteLine($"City: {City}");
                Console.WriteLine($"Country: {Country}");
                Console.WriteLine(SetFullAddress());
            }
        }
