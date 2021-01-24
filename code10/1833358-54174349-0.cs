    //I would prob use a list bc it will throw an exception when i reaches 99
        for (int i = 0; i < buffer.Length; i += 3) // normally you should always start with i = 0
            {
                //if (i + 1 % 3 == 0) // no need for this anymore, we got i += 3
                //{
                //}
                    int k = rnd.Next(1, 30);
                    buffer[i] = k;
                    buffer[i+1] = k;
                    buffer[i+2] = k;
                Console.Write($"{k} {k} {k} ");
            }
            //for (int i = 0; i < buffer.Length; i += 3) // skip the whole loop because it is/ was the same as the one above
            //{
            //}
