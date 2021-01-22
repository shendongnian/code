    Dictionary<string, string> persons = new Dictionary<string, string>();
    persons.Add("roger", "12");
    persons.Add("mary", "13");
    for (int i = 0; i < persons.Count; i++){ 
    Console.WriteLine("Name: " + persons[i].Key + ", Age: " + persons[i].Value); 
    persons.Add("Xico", "22");
    }
