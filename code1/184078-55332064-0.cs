    string[] name = new string[] { "Venu", "Bharath", "Sanjay", "Sarath", "Sandhiya", "Banu", "Gowtham", "Abdul Rahman", "Anamika", "Alex", "Austin", "Gilbert" };
    var _lqResult = from nm in name where nm.StartsWith("A") select nm;
            if (_lqResult.Count() > 1)
            {
                foreach (var n in _lqResult)
                {
                    Console.WriteLine(n);
                }
            }
            else {
                Console.WriteLine("NO RESULT AVAILABLE");
            }
