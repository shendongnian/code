    var newPhone = new Phone() {
            PhoneNumber = newNumber
        };
    try {
        pdb.Phones.Add(newPhone);
        pdb.SaveChanges();
    } catch (Exception e) {
        Console.WriteLine("COULD NOT ADD new number: {0}", e.Message);
    }
