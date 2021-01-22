            List<Temp> list = new List<Temp>();
            for (var i = 0; i < 123456; i++)
            {
                var a = new Temp(i, i, i, i);
                list.Insert(i / 2, a);
            }
            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
