    public void ReadList<T>(List<T> list) {
        try {
            for (int i = 0; i < list.Count; i++) {
                Type myObject = list[i].GetType();
                // just get the array of properties without "Select"
                var propertyInfo = myObject.GetProperties();
                foreach (var prop in propertyInfo) {
                    Console.WriteLine("Property Name : " + prop.Name);
                    // Here you can call "GetValue", with the object being "list[i]"
                    Console.WriteLine("Property Value : " + prop.GetValue(list[i]));
                }
            }
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            //throw;
        }
    }
