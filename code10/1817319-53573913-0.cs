            string userInputColRela = "input1:Student_Name, input2:Student_Age";
            string input = "input1";
            var args = userInputColRela.Split(',');
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            foreach (var item in args)
            {
                var data = item.Split(':');
                inputs.Add(data[0], data[1]);
            }
            Console.WriteLine(inputs[input]);
