            public ObservableCollection<Car> cars { get; set; }
    
            public void LoadCars()
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
    
                StreamReader reader = new StreamReader("CarsDatabase.xml");
                var catalog = (Catalog)serializer.Deserialize(reader);
                cars = new ObservableCollection<Car>(catalog.Car);
                reader.Close();
            }
    
            [Serializable()]
            public class Car
            {
                [XmlElement(ElementName = "model")]
                public string Model { get; set; }
                [XmlElement(ElementName = "year")]
                public string Year { get; set; }
                [XmlElement(ElementName = "producer")]
                public string Producer { get; set; }
                [XmlElement(ElementName = "price")]
                public string Price { get; set; }
                [XmlElement(ElementName = "owner")]
                public string Owner { get; set; }
                [XmlElement(ElementName = "tel")]
                public string Tel { get; set; }
                [XmlElement(ElementName = "mileage")]
                public string Mileage { get; set; }
                [XmlElement(ElementName = "registered")]
                public string Registered { get; set; }
                [XmlElement(ElementName = "image")]
                public string Image { get; set; }
                [XmlAttribute(AttributeName = "id")]
                public string Id { get; set; }
            }
    
            [Serializable()]
            [XmlRootAttribute("catalog", Namespace = "", IsNullable = false)]
            public class Catalog
            {
                [XmlElement(ElementName = "car")]
                public List<Car> Car { get; set; }
            }
