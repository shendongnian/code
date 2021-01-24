    //Declare typed list of Animals
                List<Animal> AllAnimals = new List<Animal>();
    
                //Declare typed list of Flowers
                List<Flower> AllFlowers = new List<Flower>();
                DataTable dt;
                //Load JSON file data
                using (StreamReader r = new StreamReader(JSONFilePath))
                {
                    string json = r.ReadToEnd();
    				//convert JSON data to datatable
                    dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                }
               foreach(DataRow row in dt.Rows)
                {
                    if (row[1].ToString() == "Animal")
                    {
                        Animal NewAnimal = new Animal();
                        NewAnimal.id = row[0].ToString();
                        NewAnimal.isMammal = row[2].ToString();
                        AllAnimals.Add(NewAnimal);
                    }
                    else
                    {
                        Flower NewFlower = new Flower();
                        NewFlower.id = row[0].ToString();
                        NewFlower.numberOfPetals = row[3].ToString();
                        AllFlowers.Add(NewFlower);
                    }
                }
