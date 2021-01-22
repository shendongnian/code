            LinkedList<Temp> list = new LinkedList<Temp>();
            for (var i = 0; i < 12345678; i++)
            {
                var a = new Temp(i, i, i, i);
                list.AddLast(a);
            }
            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
