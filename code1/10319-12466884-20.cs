            List<Temp> list = new List<Temp>(); // 2.4 seconds
 
            for (var i = 0; i < 12345678; i++)
            {
                var a = new Temp(i, i, i, i);
                list.Add(a);
            }
            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
