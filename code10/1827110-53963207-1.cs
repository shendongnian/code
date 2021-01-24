            var all = new List<Data>();
            using (var reader = new StreamReader(File.Open("data.txt", FileMode.Open)))
            {
                using (var jr = new MyJsonTextReader(reader))
                {
                    do
                    {
                        all.Add(js.Deserialize<Data>(jr));
                    } while (!jr.ObjectDone());
                }
            }
