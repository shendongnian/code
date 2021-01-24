        [MapsTo(typeof(Dog))]
        public class Pet
        {
            [MapsToProperty(typeof(Dog), "Name")]
            public string PetName { get; set; }
        }
